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

namespace ChallengeN5.Application.Permissions.GetById
{
    internal sealed class GetByIdQueryPermissionHandler : IRequestHandler<GetByIdPermissionQuery, ErrorOr<PermissionResponse>>
    {
        private readonly IRepository<Permission> _PermissionRepository;

        public GetByIdQueryPermissionHandler(IRepository<Permission> PermissionRepository)
        {
            _PermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
        }

        public async Task<ErrorOr<PermissionResponse>> Handle(GetByIdPermissionQuery query, CancellationToken cancellationToken)
        {

            if (await _PermissionRepository.GetByIdAsync(query.Id) is not Permission Permission)
            {
                return Error.NotFound("Permission.NotFound", "The Permission with the provide Id was not found.");
            }

            return new PermissionResponse(
                    Permission.Id,
                    new EmployeeResponse(
                        Permission.Employee.Id,
                        Permission.Employee.Name,
                        Permission.Employee.LastName,
                        Permission.Employee.Email,
                        Permission.Employee.PhoneNumber),
                    new PermissionTypeResponse(
                        Permission.PermissionType.Id,
                        Permission.PermissionType.Name));
        }


    }
}
