using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Application.PermissionTypes.Common;

namespace ChallengeN5.Application.Permissions.Common
{
    public record PermissionResponse(Guid Id, EmployeeResponse Employee, PermissionTypeResponse PermissionType);
}
