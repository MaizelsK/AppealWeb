using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Entities
{
    public class UserLogin
    {
        [Key]
        public virtual long UserId { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
    }
}
