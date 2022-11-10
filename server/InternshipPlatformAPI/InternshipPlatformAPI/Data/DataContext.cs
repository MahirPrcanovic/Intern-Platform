using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace InternshipPlatformAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Selection>? Selections { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<ApplicationComment>? ApplicationComments { get; set; }
        public DbSet<SelectionComment>? SelectionComments { get; set; }

    }
}
