using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_of_Joe.Models
{
    public class Portfolio_of_JoeContext : DbContext
    {
        public Portfolio_of_JoeContext (DbContextOptions<Portfolio_of_JoeContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio_of_Joe.Models.Hero> Hero { get; set; }
    }
}
