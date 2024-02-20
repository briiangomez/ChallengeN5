using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeN5.Application.Permissions.Common;

namespace ChallengeN5.Application.Employees.Common
{
    public record EmployeeResponse
        (Guid Id,
        string Name,
        string LastName,
        string Email,
        string PhoneNumber);
}
