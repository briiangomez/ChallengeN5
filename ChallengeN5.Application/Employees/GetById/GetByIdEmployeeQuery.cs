using ChallengeN5.Application.Employees.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.GetById
{
    public record GetByIdEmployeeQuery(Guid Id) : IRequest<ErrorOr<EmployeeResponse>>;
}
