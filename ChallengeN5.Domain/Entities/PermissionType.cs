using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Domain.Entities
{
    public sealed class PermissionType : EntityBase
    {
        public PermissionType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public PermissionType()
        {
            
        }

        public string Name { get; set; }

    }
}
