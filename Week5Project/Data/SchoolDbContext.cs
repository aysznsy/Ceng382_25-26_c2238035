using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Week5Project.Models;

namespace Week5Project.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}