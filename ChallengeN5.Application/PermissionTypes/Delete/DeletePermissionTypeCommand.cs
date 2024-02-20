using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Delete
{
    public record DeletePermissionTypeCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
