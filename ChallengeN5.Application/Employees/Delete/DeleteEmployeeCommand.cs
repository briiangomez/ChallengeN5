using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.Delete
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
