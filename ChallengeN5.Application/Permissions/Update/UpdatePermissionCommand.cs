using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.Update
{
    public record UpdatePermissionCommand(Guid Id, Guid EmployeeId, Guid PermissionTypeId) : IRequest<ErrorOr<Unit>>;
}
