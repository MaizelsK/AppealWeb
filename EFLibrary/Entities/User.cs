using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EFLibrary.Entities
{
    public class User : IdentityUser, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}