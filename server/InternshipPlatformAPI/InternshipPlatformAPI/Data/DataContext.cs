using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InternshipPlatformAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Application>().Navigation(c => c.Comments).AutoInclude();
            builder.Entity<Application>().Navigation(c => c.Selections).AutoInclude();
            builder.Entity<ApplicationComment>().Navigation(c => c.Comment).AutoInclude();
            builder.Entity<ApplicationComment>().Navigation(c => c.Application).AutoInclude();
            builder.Entity<ApplicationComment>().Navigation(c => c.User).AutoInclude();
            base.OnModelCreating(builder);
        }
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Selection>? Selections { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<ApplicationComment>? ApplicationComments { get; set; }
        public DbSet<SelectionComment>? SelectionComments { get; set; }
    }
}
