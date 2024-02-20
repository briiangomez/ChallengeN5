using ChallengeN5.Application.Permissions.Update;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Update
{
    internal sealed class UpdatePermissionTypeCommandHandler : IRequestHandler<UpdatePermissionTypeCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<PermissionType> _PermissionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePermissionTypeCommandHandler(IRepository<PermissionType> PermissionTypeRepository, IUnitOfWork unitOfWork)
        {
            _PermissionTypeRepository = PermissionTypeRepository ?? throw new ArgumentNullException(nameof(PermissionTypeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdatePermissionTypeCommand command, CancellationToken cancellationToken)
        {
            if (!await _PermissionTypeRepository.ExistsAsync(command.Id))
            {
                return Error.NotFound("PermissionType.NotFound", "The PermissionType with the provide Id was not found.");
            }


            PermissionType PermissionType = new PermissionType(command.Id, command.Name);

            _PermissionTypeRepository.Update(PermissionType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
