using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.Update
{
    public record UpdateEmployeeCommand
    (Guid Id,
        string Name,
        string LastName,
        string Email,
        string PhoneNumber,
        List<Permission> Permissions) : IRequest<ErrorOr<Unit>>;
}
