using ChallengeN5.Application.Permissions.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Permissions.GetById
{
    public record GetByIdPermissionQuery(Guid Id) : IRequest<ErrorOr<PermissionResponse>>;
}
