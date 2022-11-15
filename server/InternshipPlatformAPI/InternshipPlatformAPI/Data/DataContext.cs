using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace InternshipPlatformAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Application>().HasData(new Application
            {
                FirstName="Mahir",
                LastName="Prcanovic",
                EducationLevel="College-Undergraduate",
                Email="mahirprcanovic@gmail.com",
                CoverLetter="cover letter",
                CV= "https://github.com/MahirPrcanovic"
            },
            new Application
            {
                FirstName = "Adna",
                LastName = "Salcin",
                EducationLevel = "Master-Undergraduate",
                Email = "adnasalcin@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://github.com/asalcin3"
            },
            new Application
            {
                FirstName = "Lewis",
                LastName = "Hamilton",
                EducationLevel = "Doctor-Undergraduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://lewis.com/cv"
            },
            new Application
            {
                FirstName = "Emilia",
                LastName = "Clarke",
                EducationLevel = "College-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://emilia.com/cv"
            },
            new Application
            {
                FirstName = "Olivia",
                LastName = "Wilde",
                EducationLevel = "Master-Undergraduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://olivia.com/cv"
            },
            new Application
            {
                FirstName = "Henry",
                LastName = "Cavill",
                EducationLevel = "Master-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://henry.com/cv"
            },
            new Application
            {
                FirstName = "Ryan",
                LastName = "Reynolds",
                EducationLevel = "College-Undergraduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://ryan.com/cv"
            },
            new Application
            {
                FirstName = "Tom",
                LastName = "Hardy",
                EducationLevel = "Master-Undergraduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://tom.com/cv"
            },
            new Application
            {
                FirstName = "Jack",
                LastName = "Whitehall",
                EducationLevel = "Doctor-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://jack.com/cv"
            },
            new Application
            {
                FirstName = "John",
                LastName = "Doe",
                EducationLevel = "College-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://john.com/cv"
            },
            new Application
            {
                FirstName = "Lorem",
                LastName = "Ipsum",
                EducationLevel = "HighSchool-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://loremipsum.com"
            },
            new Application
            {
                FirstName = "Mick",
                LastName = "Schumacher",
                EducationLevel = "College-Graduate",
                Email = "mahirprcanovic@gmail.com",
                CoverLetter = "cover letter",
                CV = "https://mick.com"
            });
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string EDITOR_ROLE_ID = "413743e0-asd2–42fe-afbf-59kmccmk72cd6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID,
            },new IdentityRole
            {
                Name="Editor",
                NormalizedName="EDITOR",
                Id = EDITOR_ROLE_ID,
                ConcurrencyStamp = EDITOR_ROLE_ID
            });
            var adminUser = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                EmailConfirmed = true,
                NormalizedUserName="ADMIN",
            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "admin123");
            builder.Entity<IdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
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
