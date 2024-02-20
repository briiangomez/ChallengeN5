using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Domain.Entities
{
    public sealed class Permission : EntityBase
    {
        public Permission(Guid id, Guid permissionId, Guid employeeId)
        {
            Id = id;
            EmployeeId = employeeId;
            PermissionId = permissionId;

        }
        public Guid PermissionId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; private set; }
        public PermissionType PermissionType { get; private set; }
    }
}
