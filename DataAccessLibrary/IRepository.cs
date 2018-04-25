using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IRepository<Entity, Key> : IDisposable where Entity : class
    {
        IEnumerable<Entity> GetList();
        Task<Entity> FindByIdAsync(Key id);
        Task CreateAsync(Entity item);
        Task UpdateAsync(Entity item);
        Task DeleteAsync(Entity item);
    }
}
