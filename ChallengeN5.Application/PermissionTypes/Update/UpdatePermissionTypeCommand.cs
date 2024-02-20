using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Update
{
    public record UpdatePermissionTypeCommand(Guid Id, string Name) : IRequest<ErrorOr<Unit>>;
}
