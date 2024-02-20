using ChallengeN5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Infrastructure.Contracts
{
    public interface IChallengeN5DbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<PermissionType> PermissionTypes { get; set; }
        DbSet<Permission> Permissions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
