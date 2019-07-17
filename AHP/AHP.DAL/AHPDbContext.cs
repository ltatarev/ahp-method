using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP.DAL
{
    public class AHPDbContext : DbContext
    {
        public AHPDbContext() : base("AHPDbContext")
        {
        }

        // Add DbSet<T>
    }
}
