using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.Create
{
    public record CreatePermissionCommand(Guid EmployeeId, Guid PermissionTypeId) : IRequest<ErrorOr<Guid>>;
}
