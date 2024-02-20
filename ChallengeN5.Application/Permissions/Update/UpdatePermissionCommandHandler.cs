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

namespace ChallengeN5.Application.Permissions.Update
{
    internal sealed class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<Permission> _PermissionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePermissionCommandHandler(IRepository<Permission> PermissionRepository, IUnitOfWork unitOfWork)
        {
            _PermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdatePermissionCommand command, CancellationToken cancellationToken)
        {
            if (!await _PermissionRepository.ExistsAsync(command.Id))
            {
                return Error.NotFound("Permission.NotFound", "The Permission with the provide Id was not found.");
            }


            Permission Permission = new Permission(command.Id, command.PermissionTypeId,
                command.EmployeeId);

            _PermissionRepository.Update(Permission);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
