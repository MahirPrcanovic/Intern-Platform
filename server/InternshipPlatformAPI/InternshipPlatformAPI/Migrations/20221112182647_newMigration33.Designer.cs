﻿// <auto-generated />
using System;
using InternshipPlatformAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternshipPlatformAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221112182647_newMigration33")]
    partial class newMigration33
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationSelection", b =>
                {
                    b.Property<Guid>("ApplicationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SelectionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationsId", "SelectionsId");

                    b.HasIndex("SelectionsId");

                    b.ToTable("ApplicationSelection");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0663a11a-735e-46da-8d6e-3fdca35d9c7d"),
                            CV = "https://github.com/MahirPrcanovic",
                            CoverLetter = "cover letter",
                            EducationLevel = "College-Undergraduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Mahir",
                            LastName = "Prcanovic",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("a4efcaf4-3fe2-49f0-a8ae-10b8370894d8"),
                            CV = "https://github.com/asalcin3",
                            CoverLetter = "cover letter",
                            EducationLevel = "Master-Undergraduate",
                            Email = "adnasalcin@gmail.com",
                            FirstName = "Adna",
                            LastName = "Salcin",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("00464308-a505-4c1b-ab1b-8a5e3ab6b8a9"),
                            CV = "https://lewis.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "Doctor-Undergraduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Lewis",
                            LastName = "Hamilton",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("640635eb-ac24-456d-a65e-bd55eda8aeff"),
                            CV = "https://emilia.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "College-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Emilia",
                            LastName = "Clarke",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("729b84fb-41d0-4e0c-acc1-69847fb00b84"),
                            CV = "https://olivia.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "Master-Undergraduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Olivia",
                            LastName = "Wilde",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("fc90edd0-7be8-4101-a103-dbb2c29780bb"),
                            CV = "https://henry.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "Master-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Henry",
                            LastName = "Cavill",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("3cfdc753-0ab7-45e4-a982-97c8800744ee"),
                            CV = "https://ryan.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "College-Undergraduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Ryan",
                            LastName = "Reynolds",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("0da91440-a1b1-409a-b166-15c758174302"),
                            CV = "https://tom.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "Master-Undergraduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Tom",
                            LastName = "Hardy",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("3eaac498-aafb-41a1-b758-ddbff0eb3641"),
                            CV = "https://jack.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "Doctor-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Jack",
                            LastName = "Whitehall",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("5624333e-b193-4793-a544-9c6e7fa196a4"),
                            CV = "https://john.com/cv",
                            CoverLetter = "cover letter",
                            EducationLevel = "College-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("57098063-5a38-4a97-97e6-62371a4f1bf6"),
                            CV = "https://loremipsum.com",
                            CoverLetter = "cover letter",
                            EducationLevel = "HighSchool-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Lorem",
                            LastName = "Ipsum",
                            Status = "applied"
                        },
                        new
                        {
                            Id = new Guid("7754156a-ec04-4e35-839b-84d4102feb16"),
                            CV = "https://mick.com",
                            CoverLetter = "cover letter",
                            EducationLevel = "College-Graduate",
                            Email = "mahirprcanovic@gmail.com",
                            FirstName = "Mick",
                            LastName = "Schumacher",
                            Status = "applied"
                        });
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.ApplicationComment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicationComments");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.Selection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.SelectionComment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SelectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("SelectionId");

                    b.HasIndex("UserId");

                    b.ToTable("SelectionComments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "413743e0-asd2–42fe-afbf-59kmccmk72cd6",
                            ConcurrencyStamp = "413743e0-asd2–42fe-afbf-59kmccmk72cd6",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b4e0601-f811-4f28-80e5-baa7c5f0741e",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEP/l6Dz5NnvMf/rS5STPSQZJodfxbWeIoKoWylUIlbZ7Ak1D9wFUqb63I27bdh0AnQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "db7c2303-c3de-44cd-9c3f-a29584b9a3e4",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApplicationSelection", b =>
                {
                    b.HasOne("InternshipPlatformAPI.Models.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipPlatformAPI.Models.Selection", null)
                        .WithMany()
                        .HasForeignKey("SelectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.ApplicationComment", b =>
                {
                    b.HasOne("InternshipPlatformAPI.Models.Application", "Application")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("InternshipPlatformAPI.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Application");

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.SelectionComment", b =>
                {
                    b.HasOne("InternshipPlatformAPI.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("InternshipPlatformAPI.Models.Selection", "Selection")
                        .WithMany("SelectionComments")
                        .HasForeignKey("SelectionId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("Selection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.Application", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("InternshipPlatformAPI.Models.Selection", b =>
                {
                    b.Navigation("SelectionComments");
                });
#pragma warning restore 612, 618
        }
    }
}
