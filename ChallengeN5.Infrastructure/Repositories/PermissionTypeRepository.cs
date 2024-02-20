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
    public class PermissionTypeRepository : IRepository<PermissionType>
    {
        private readonly ChallengeN5DbContext _context;

        public PermissionTypeRepository(ChallengeN5DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(PermissionType customer) => _context.PermissionTypes.Add(customer);
        public void Delete(PermissionType customer) => _context.PermissionTypes.Remove(customer);
        public void Update(PermissionType customer) => _context.PermissionTypes.Update(customer);
        public async Task<bool> ExistsAsync(Guid id) => await _context.PermissionTypes.AnyAsync(customer => customer.Id == id);
        public async Task<PermissionType?> GetByIdAsync(Guid id) => await _context.PermissionTypes.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<PermissionType>> GetAll() => await _context.PermissionTypes.ToListAsync();
    }
}
