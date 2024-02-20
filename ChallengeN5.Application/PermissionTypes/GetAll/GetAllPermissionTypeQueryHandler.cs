using ChallengeN5.Application.PermissionTypes.Common;
using ChallengeN5.Application.PermissionTypes.GetAll;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.GetAll
{
    internal sealed class GetAllPermissionTypeQueryHandler : IRequestHandler<GetAllPermissionTypeQuery, ErrorOr<List<PermissionTypeResponse>>>
    {
        private readonly IRepository<PermissionType> _PermissionTypeRepository;

        public GetAllPermissionTypeQueryHandler(IRepository<PermissionType> PermissionTypeRepository)
        {
            _PermissionTypeRepository = PermissionTypeRepository ?? throw new ArgumentNullException(nameof(PermissionTypeRepository));
        }

        public async Task<ErrorOr<List<PermissionTypeResponse>>> Handle(GetAllPermissionTypeQuery query, CancellationToken cancellationToken)
        {
            List<PermissionType> PermissionTypes = await _PermissionTypeRepository.GetAll();

            return PermissionTypes.Select(PermissionType => new PermissionTypeResponse(
                    PermissionType.Id,
                    PermissionType.Name)
                ).ToList();
        }
    }
}
