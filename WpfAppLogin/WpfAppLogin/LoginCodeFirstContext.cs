using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLogin
{
    class LoginCodeFirstContext:DbContext
    {
        public LoginCodeFirstContext(): base("name=devDB")
        {

        }
        public DbSet<LoginDetail> LoginDetails { get; set; }    
    }
}
