using DataAccessLibrary.Entities;
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
        Entity FindById(Key id);

        Task CreateAsync(Entity item);
        void Create(Entity item);

        Task CreateAppealAsync(Appeal appeal, long userId);
        void CreateAppeal(Appeal appeal, long userId);

        Task UpdateAsync(Entity item);
        void Update(Entity item);

        Task DeleteAsync(Entity item);
        void Delete(Entity item);
    }
}
