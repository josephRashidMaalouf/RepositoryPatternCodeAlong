using Infrastructure.sql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.sql
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Person> People => Set<Person>();
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
