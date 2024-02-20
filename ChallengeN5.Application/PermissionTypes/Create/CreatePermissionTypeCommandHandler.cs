using ChallengeN5.Application.PermissionTypes.Create;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Create
{
    public sealed class CreatePermissionTypeCommandHandler : IRequestHandler<CreatePermissionTypeCommand, ErrorOr<Guid>>
    {
        private readonly IRepository<PermissionType> _PermissionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePermissionTypeCommandHandler(IRepository<PermissionType> PermissionTypeRepository, IUnitOfWork unitOfWork)
        {
            _PermissionTypeRepository = PermissionTypeRepository ?? throw new ArgumentNullException(nameof(PermissionTypeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreatePermissionTypeCommand command, CancellationToken cancellationToken)
        {

            var PermissionType = new PermissionType(
                Guid.NewGuid(),
                command.name            
                );

            _PermissionTypeRepository.Add(PermissionType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return PermissionType.Id;
        }
    }
}
