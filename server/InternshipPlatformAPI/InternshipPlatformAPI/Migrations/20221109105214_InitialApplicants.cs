using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPlatformAPI.Migrations
{
    public partial class InitialApplicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("2c851f2b-d047-4ee0-9585-0a3029484f92"));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { new Guid("ef634480-972e-47bd-bd9c-d785840ef799"), "https://github.com/MahirPrcanovic", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { new Guid("fb3c05ce-42cd-42f0-a69e-f72834806efb"), "https://github.com/asalcin3", "cover letter", "Master-Undergraduate", "adnasalcin@gmail.com", "Adna", "Salcin", "applied" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0473af-7d9e-40e9-b4c4-7349294a889b", "AQAAAAEAACcQAAAAEELhAdcygXfHCJKT0HeQYdjS4cdiKCJ8z/HiULrm0/m8XHbN1dhUA9Cc4OgydmPgcg==", "ba6b1942-7824-4f8b-9389-12367b95f04e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("ef634480-972e-47bd-bd9c-d785840ef799"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("fb3c05ce-42cd-42f0-a69e-f72834806efb"));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[] { new Guid("2c851f2b-d047-4ee0-9585-0a3029484f92"), "", "", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e8a69f0-d960-49d3-a001-7eb084274a25", "AQAAAAEAACcQAAAAECHNQaBfAkARis+wa03169VMwzAH05BV5K2mZy/fzDQ2LZ2MkOKfsfVRcP55107R4w==", "9f30a1a1-1f95-4c06-b2bb-42368f8312ed" });
        }
    }
}
