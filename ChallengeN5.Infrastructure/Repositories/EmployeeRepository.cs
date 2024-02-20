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
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ChallengeN5DbContext _context;

        public EmployeeRepository(ChallengeN5DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Employee customer) => _context.Employees.Add(customer);
        public void Delete(Employee customer) => _context.Employees.Remove(customer);
        public void Update(Employee customer) => _context.Employees.Update(customer);
        public async Task<bool> ExistsAsync(Guid id) => await _context.Employees.AnyAsync(customer => customer.Id == id);
        public async Task<Employee?> GetByIdAsync(Guid id) => await _context.Employees.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Employee>> GetAll() => await _context.Employees.ToListAsync();
    }
}
