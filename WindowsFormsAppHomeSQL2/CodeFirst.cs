using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppHomeSQL2
{
    class CodeFirst:DbContext
    {
        public CodeFirst():base("conStr")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
