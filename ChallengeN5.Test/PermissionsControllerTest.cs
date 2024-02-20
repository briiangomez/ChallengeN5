using ChallengeN5.Application.Permissions.Common;
using ChallengeN5.Application.Permissions.GetAll;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Infrastructure.Services;
using ChallengeN5.WebApi.Controllers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Nest;
using Serilog.Core;
using System.Diagnostics;

namespace ChallengeN5.Test
{
    public class PermissionsControllerTest 
    {
        PermissionController _controller;
        private readonly Mock<ISender> _mediator;

        private readonly Mock<ILogger<PermissionController>> _logger;

        private readonly Mock<IElasticClient> _elasticClient;

        private readonly Mock<ProducerService> _kafkaService;

        public PermissionsControllerTest()
        {
            _mediator = new Mock<ISender>();
            _logger = new Mock<ILogger<PermissionController>>();
            _elasticClient = new Mock<IElasticClient>();
            _kafkaService = new Mock<ProducerService>();
            _controller = new PermissionController(_mediator.Object,_logger.Object,_elasticClient.Object, _kafkaService.Object);
        }


        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.GetAll();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);

        }
    }
}