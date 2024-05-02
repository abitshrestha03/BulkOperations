using Day12First.Models;
using Microsoft.EntityFrameworkCore;

namespace Day12First.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Fruit> Fruits { get; set; }
    }
}
