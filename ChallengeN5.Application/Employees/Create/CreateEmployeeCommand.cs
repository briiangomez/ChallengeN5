using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.Create
{
    public record CreateEmployeeCommand
    (Guid Id,
        string Name,
        string LastName,
        string Email,
        string PhoneNumber,
        List<Permission> Permissions) : IRequest<ErrorOr<Guid>>;
}
