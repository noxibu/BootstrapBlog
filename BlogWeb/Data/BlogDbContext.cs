using BlogWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
