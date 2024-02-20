using ChallengeN5.Application.Permissions.Create;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.Create
{
    public sealed class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<Guid>>
    {
        private readonly IRepository<Permission> _PermissionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePermissionCommandHandler(IRepository<Permission> PermissionRepository, IUnitOfWork unitOfWork)
        {
            _PermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
        {

            var Permission = new Permission(
                Guid.NewGuid(),
                command.PermissionTypeId,
                command.EmployeeId    
            );

            _PermissionRepository.Add(Permission);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Permission.Id;
        }
    }
}
