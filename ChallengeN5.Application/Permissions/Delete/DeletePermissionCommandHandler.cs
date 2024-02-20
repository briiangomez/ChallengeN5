using ChallengeN5.Application.Permissions.Delete;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.Delete
{
    internal sealed class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<Permission> _PermissionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePermissionCommandHandler(IRepository<Permission> PermissionRepository, IUnitOfWork unitOfWork)
        {
            _PermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeletePermissionCommand command, CancellationToken cancellationToken)
        {
            if (await _PermissionRepository.GetByIdAsync(command.Id) is not Permission Permission)
            {
                return Error.NotFound("Permission.NotFound", "The Permission with the provide Id was not found.");
            }

            _PermissionRepository.Delete(Permission);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
