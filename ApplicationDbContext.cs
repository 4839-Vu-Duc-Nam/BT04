using Microsoft.EntityFrameworkCore;
using BT04.Models;

namespace BT04.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
