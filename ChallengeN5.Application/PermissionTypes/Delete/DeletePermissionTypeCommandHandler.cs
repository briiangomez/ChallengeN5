using ChallengeN5.Application.PermissionTypes.Delete;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Delete
{
    internal sealed class DeletePermissionTypeCommandHandler : IRequestHandler<DeletePermissionTypeCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<PermissionType> _PermissionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePermissionTypeCommandHandler(IRepository<PermissionType> PermissionTypeRepository, IUnitOfWork unitOfWork)
        {
            _PermissionTypeRepository = PermissionTypeRepository ?? throw new ArgumentNullException(nameof(PermissionTypeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeletePermissionTypeCommand command, CancellationToken cancellationToken)
        {
            if (await _PermissionTypeRepository.GetByIdAsync(command.Id) is not PermissionType PermissionType)
            {
                return Error.NotFound("PermissionType.NotFound", "The Permission Type with the provide Id was not found.");
            }

            _PermissionTypeRepository.Delete(PermissionType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
