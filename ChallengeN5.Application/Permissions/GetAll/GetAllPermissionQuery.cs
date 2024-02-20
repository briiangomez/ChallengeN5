using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Application.Permissions.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.GetAll
{
    public record GetAllPermissionQuery() : IRequest<ErrorOr<List<PermissionResponse>>>;
}
