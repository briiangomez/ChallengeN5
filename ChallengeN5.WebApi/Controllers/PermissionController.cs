using Microsoft.AspNetCore.Mvc;
using Serilog;
using ChallengeN5.Application.Permissions.Create;
using ChallengeN5.Application.Permissions.Update;
using ChallengeN5.Application.Permissions.GetById;
using ChallengeN5.Application.Permissions.Delete;
using ChallengeN5.Application.Permissions.GetAll;
using MediatR;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Nest;
using ChallengeN5.Infrastructure.Services;
using Azure.Core;
using System.Text.Json;


namespace ChallengeN5.WebApi.Controllers
{
    [Route("permissions")]
    public class PermissionController : ApiController
    {
        private readonly ISender _mediator;

        private readonly ILogger<PermissionController> _logger;

        private readonly IElasticClient _elasticClient;

        private readonly ProducerService _kafkaService;


        public PermissionController(ISender mediator, ILogger<PermissionController> logger, IElasticClient elasticClient, ProducerService producerService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
            _kafkaService = producerService ?? throw new ArgumentNullException(nameof(producerService));
            Log.Information("PermissionController controller called ");
        }


        [HttpGet]
        [Route("/GetPermissions")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Log.Information($"Method called {nameof(GetAll)} => /GetPermissions");
                var permissionsResult = await _mediator.Send(new GetAllPermissionQuery());

                var message = JsonSerializer.Serialize(new KafkaMessage(Guid.NewGuid(), "get"));

                await _kafkaService.ProduceAsync("PermissionsRequest", message);

                return permissionsResult.Match(
                permissions => Ok(permissions),
                errors => Problem(errors)
                );
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error - An error occurred while processing the request.");
            }
        }


        [HttpPost]
        [Route("/RequestPermission")]
        public async Task<IActionResult> Create([FromBody] CreatePermissionCommand command)
        {
            try
            {
                Log.Information($"Method called {nameof(Create)} => /RequestPermission");
                var createResult = await _mediator.Send(command);
                await _elasticClient.IndexDocumentAsync(command);

                var message = JsonSerializer.Serialize(new KafkaMessage(Guid.NewGuid(), "request"));

                await _kafkaService.ProduceAsync("PermissionsRequest", message);

                return createResult.Match(
                permission => Ok(permission),
                errors => Problem(errors)
                );
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error - An error occurred while processing the request.");
            }

        }

        [HttpPut("/ModifyPermission/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePermissionCommand command)
        {
            try
            {
                Log.Information($"Method called {nameof(Update)} => /ModifyPermission/{id}");
                if (command.Id != id)
                {
                    List<Error> errors = new()
                    {
                        Error.Validation("Permission.UpdateInvalid", "The request Id does not match with the url Id.")
                    };
                    return Problem(errors);
                }

                var updateResult = await _mediator.Send(command);

                var message = JsonSerializer.Serialize(new KafkaMessage(Guid.NewGuid(), "modify"));

                await _kafkaService.ProduceAsync("PermissionsRequest", message);

                return updateResult.Match(
                    permissionId => NoContent(),
                    errors => Problem(errors)
                );
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal Server Error - An error occurred while processing the request.");
            }
        }
    }
}
