using Day1.Model;
using Microsoft.EntityFrameworkCore;

namespace Day1
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
