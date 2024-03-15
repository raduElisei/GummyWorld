using GummyWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GummyWorld.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();
}
