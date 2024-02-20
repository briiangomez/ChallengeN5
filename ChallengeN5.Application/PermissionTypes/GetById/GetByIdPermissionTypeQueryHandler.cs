using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Application.Permissions.Common;
using ChallengeN5.Application.Permissions.GetById;
using ChallengeN5.Application.PermissionTypes.Common;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.GetById
{
    internal sealed class GetByIdQueryPermissionTypeHandler : IRequestHandler<GetByIdPermissionTypeQuery, ErrorOr<PermissionTypeResponse>>
    {
        private readonly IRepository<PermissionType> _PermissionTypeRepository;

        public GetByIdQueryPermissionTypeHandler(IRepository<PermissionType> PermissionTypeRepository)
        {
            _PermissionTypeRepository = PermissionTypeRepository ?? throw new ArgumentNullException(nameof(PermissionTypeRepository));
        }

        public async Task<ErrorOr<PermissionTypeResponse>> Handle(GetByIdPermissionTypeQuery query, CancellationToken cancellationToken)
        {

            if (await _PermissionTypeRepository.GetByIdAsync(query.Id) is not PermissionType PermissionType)
            {
                return Error.NotFound("PermissionType.NotFound", "The PermissionType with the provide Id was not found.");
            }

            return new PermissionTypeResponse(
                    PermissionType.Id,
                    PermissionType.Name);
        }


    }
}
