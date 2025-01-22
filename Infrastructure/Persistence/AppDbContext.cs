using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Person> People => Set<Person>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}