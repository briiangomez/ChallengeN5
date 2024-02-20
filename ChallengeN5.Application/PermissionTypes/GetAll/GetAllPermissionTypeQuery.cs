using ChallengeN5.Application.PermissionTypes.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.PermissionTypes.GetAll
{
    public record GetAllPermissionTypeQuery() : IRequest<ErrorOr<List<PermissionTypeResponse>>>;
}
