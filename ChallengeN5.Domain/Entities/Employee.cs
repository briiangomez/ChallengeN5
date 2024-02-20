using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChallengeN5.Domain.Entities
{
    public sealed class Employee : EntityBase
    {
        public Employee()
        {
                
        }
        public Employee(Guid id, string name, string lastName, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Permissions = new List<Permission>();

        }

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{Name} {LastName}";
        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public List<Permission> Permissions { get; set; }
    }
}
