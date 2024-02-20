using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ChallengeN5.Infrastructure.Context.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Infrastructure.Repositories
{
    public class PermissionRepository : IRepository<Permission>
    {
        private readonly ChallengeN5DbContext _context;

        public PermissionRepository(ChallengeN5DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Permission customer) => _context.Permissions.Add(customer);
        public void Delete(Permission customer) => _context.Permissions.Remove(customer);
        public void Update(Permission customer) => _context.Permissions.Update(customer);
        public async Task<bool> ExistsAsync(Guid id) => await _context.Permissions.AnyAsync(customer => customer.Id == id);
        public async Task<Permission?> GetByIdAsync(Guid id) => await _context.Permissions.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Permission>> GetAll() => await _context.Permissions.Include(o => o.Employee).Include(o => o.PermissionType).ToListAsync();
    }
}
