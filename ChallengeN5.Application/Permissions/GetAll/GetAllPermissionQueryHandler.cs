using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Application.Permissions.Common;
using ChallengeN5.Application.Permissions.GetAll;
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

namespace ChallengeN5.Application.Permissions.GetAll
{
    internal sealed class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, ErrorOr<List<PermissionResponse>>>
    {
        private readonly IRepository<Permission> _PermissionRepository;

        public GetAllPermissionQueryHandler(IRepository<Permission> PermissionRepository)
        {
            _PermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
        }

        public async Task<ErrorOr<List<PermissionResponse>>> Handle(GetAllPermissionQuery query, CancellationToken cancellationToken)
        {
            List<Permission> Permissions = await _PermissionRepository.GetAll();

            return Permissions.Select(Permission => new PermissionResponse(
                    Permission.Id,
                    new EmployeeResponse(
                        Permission.Employee.Id,
                        Permission.Employee.Name,
                        Permission.Employee.LastName,
                        Permission.Employee.Email,
                        Permission.Employee.PhoneNumber),
                    new PermissionTypeResponse(
                        Permission.PermissionType.Id,
                        Permission.PermissionType.Name))
                ).ToList();
        }
    }
}
