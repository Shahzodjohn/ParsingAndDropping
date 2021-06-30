using Microsoft.EntityFrameworkCore;
using ParsingAndDropping.Entities;

namespace ParsingAndDropping.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Dropping> Droppings { get; set; }
    }
}
