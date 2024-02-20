using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        void Add(T customer);
        void Update(T customer);
        void Delete(T customer);
    }
}
