using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.Create
{
    public record CreatePermissionTypeCommand(Guid Id, string name) : IRequest<ErrorOr<Guid>>;
}
