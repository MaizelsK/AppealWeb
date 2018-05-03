using DataAccessLibrary.Entities;
using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Stores
{
    public class IdentityStore : IUserStore<User, long>, IUserPasswordStore<User, long>,
                                 IUserLockoutStore<User, long>, IUserTwoFactorStore<User, long>,
                                 IUserEmailStore<User, long>, IQueryableUserStore<User, long>
    {
        private IRepository<User, long> Repository { get; set; }
        public IQueryable<User> Users { get; }

        public IdentityStore()
        {
            Repository = RepositoryFactory.GetRepository<User, long>();
            Users = Repository.GetList().AsQueryable();
        }

        #region IUserStore<User, int>
        public Task CreateAsync(User user)
        {
            return Repository.CreateAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            return Repository.DeleteAsync(user);
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return Repository.FindByIdAsync(userId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() =>
            {
                return Repository.GetList()
                .SingleOrDefault(x => x.UserName == userName);
            });
        }

        public Task UpdateAsync(User user)
        {
            return Repository.UpdateAsync(user);
        }
        #endregion

        #region IUserPasswordStore<User, int>
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(true);
        }
        #endregion

        #region IUserLockoutStore<User, int>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.CompletedTask;
        }
        #endregion

        #region IUserTwoFactorStore<User, int>
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.CompletedTask;
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }
        #endregion

        public void Dispose()
        {
            Repository.Dispose();
        }

        public Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
            return Repository.UpdateAsync(user);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return Task.Run(() => user.EmailConfirmed = confirmed);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Task.Run(() =>
            {
                return Repository.GetList()
                .SingleOrDefault(x => x.Email == email);
            });
        }
    }
}
