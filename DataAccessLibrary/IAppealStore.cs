using DataAccessLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IAppealStore
    {
        /// <summary>
        /// Create a new Appeal
        /// </summary>
        /// <param name="appeal">Appeal to create</param>
        /// <returns></returns>
        Task CreateAsync(Appeal appeal, long userId);

        /// <summary>
        /// Delete an Appeal
        /// </summary>
        /// <param name="appeal">Id of Appeal</param>
        /// <returns></returns>
        Task DeleteAsync(Appeal appeal);

        /// <summary>
        /// Find an Appeal by id
        /// </summary>
        /// <param name="appealId">Id of Appeal</param>
        /// <returns></returns>
        Task<Appeal> FindByIdAsync(int appealId);

        /// <summary>
        /// Find an Appeal by name
        /// </summary>
        /// <param name="appealTheme">Name of Appeal</param>
        /// <returns></returns>
        Task<Appeal> FindByThemeAsync(string appealTheme);

        /// <summary>
        /// Update an Appeal
        /// </summary>
        /// <param name="appeal">Appeal to update</param>
        /// <returns></returns>
        Task UpdateAsync(Appeal appeal);
    }
}
