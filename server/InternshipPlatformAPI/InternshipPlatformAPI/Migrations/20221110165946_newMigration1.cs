using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPlatformAPI.Migrations
{
    public partial class newMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("1178764c-5ebc-4d34-8152-5fc3395b8c1f"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("1271404c-67a7-4368-8bf4-fbe39b05b62c"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("46b08fa8-733a-4fe1-bd7d-73261410eb40"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("4e5a69fc-1be7-4aeb-9e3a-ff744e704d61"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("5ab00bd0-fb84-4bd0-9ee3-e50f1dfe4685"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("5f9a2123-fd9f-469c-a4e0-c61268c306da"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("7a491f86-4cc4-4cd7-9228-2286c10f1964"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("7ce59cd3-9454-4a00-8e6f-4a8ec490713c"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("b5cbeeb0-3abf-4967-97ce-eb308a2387c5"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("be1f15d2-78c1-43b1-a5a5-e61c50f960cb"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("eeb7e313-8e7d-4911-8c3c-4db365350e26"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("f196f98f-0645-426e-a951-f2d81113676f"));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { new Guid("008b1ca2-7eea-475e-ab4e-b391a5181cda"), "https://emilia.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Emilia", "Clarke", "applied" },
                    { new Guid("1f66ab23-2d55-45f7-b292-e41502146e03"), "https://olivia.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Olivia", "Wilde", "applied" },
                    { new Guid("3756c0f3-e958-474c-93e6-f45ac9993f7e"), "https://john.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "John", "Doe", "applied" },
                    { new Guid("3e1671c3-1950-4181-b35a-6f0b2699ee62"), "https://ryan.com/cv", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Ryan", "Reynolds", "applied" },
                    { new Guid("45b240bf-04af-4333-aa65-8b5d2dea455e"), "https://jack.com/cv", "cover letter", "Doctor-Graduate", "mahirprcanovic@gmail.com", "Jack", "Whitehall", "applied" },
                    { new Guid("52a001db-4fa8-4dea-a02b-f83c5ffc788c"), "https://henry.com/cv", "cover letter", "Master-Graduate", "mahirprcanovic@gmail.com", "Henry", "Cavill", "applied" },
                    { new Guid("68e46e1f-267c-4f1c-b825-7ac9928d3b42"), "https://tom.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Tom", "Hardy", "applied" },
                    { new Guid("707c793e-aab4-42c0-9bef-eb0cde54203b"), "https://github.com/asalcin3", "cover letter", "Master-Undergraduate", "adnasalcin@gmail.com", "Adna", "Salcin", "applied" },
                    { new Guid("ce60039a-6be7-4ccb-b7e8-159563d4b69c"), "https://loremipsum.com", "cover letter", "HighSchool-Graduate", "mahirprcanovic@gmail.com", "Lorem", "Ipsum", "applied" },
                    { new Guid("eef72bd1-57ef-4c1c-9a32-554d8ace1a0f"), "https://github.com/MahirPrcanovic", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" },
                    { new Guid("f0417472-3b8a-44bf-af63-4db693f1944e"), "https://lewis.com/cv", "cover letter", "Doctor-Undergraduate", "mahirprcanovic@gmail.com", "Lewis", "Hamilton", "applied" },
                    { new Guid("fb205e20-36e8-44b5-85b6-2656f5fcad79"), "https://mick.com", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Mick", "Schumacher", "applied" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0caf19d9-f490-4934-a235-ef775bf01f8f", "AQAAAAEAACcQAAAAEIyIYp6Xwl0dFabVW7C/o9kpLV/gk5tr0agdBgfo+w9j8Gw4wmRsMS6yjn9OGfg8Yg==", "9f5bc99c-5047-41a5-8a23-8aaaf965938a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("008b1ca2-7eea-475e-ab4e-b391a5181cda"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("1f66ab23-2d55-45f7-b292-e41502146e03"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3756c0f3-e958-474c-93e6-f45ac9993f7e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3e1671c3-1950-4181-b35a-6f0b2699ee62"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("45b240bf-04af-4333-aa65-8b5d2dea455e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("52a001db-4fa8-4dea-a02b-f83c5ffc788c"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("68e46e1f-267c-4f1c-b825-7ac9928d3b42"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("707c793e-aab4-42c0-9bef-eb0cde54203b"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("ce60039a-6be7-4ccb-b7e8-159563d4b69c"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("eef72bd1-57ef-4c1c-9a32-554d8ace1a0f"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("f0417472-3b8a-44bf-af63-4db693f1944e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("fb205e20-36e8-44b5-85b6-2656f5fcad79"));

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { new Guid("1178764c-5ebc-4d34-8152-5fc3395b8c1f"), "https://tom.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Tom", "Hardy", "applied" },
                    { new Guid("1271404c-67a7-4368-8bf4-fbe39b05b62c"), "https://ryan.com/cv", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Ryan", "Reynolds", "applied" },
                    { new Guid("46b08fa8-733a-4fe1-bd7d-73261410eb40"), "https://jack.com/cv", "cover letter", "Doctor-Graduate", "mahirprcanovic@gmail.com", "Jack", "Whitehall", "applied" },
                    { new Guid("4e5a69fc-1be7-4aeb-9e3a-ff744e704d61"), "https://mick.com", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Mick", "Schumacher", "applied" },
                    { new Guid("5ab00bd0-fb84-4bd0-9ee3-e50f1dfe4685"), "https://github.com/MahirPrcanovic", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" },
                    { new Guid("5f9a2123-fd9f-469c-a4e0-c61268c306da"), "https://henry.com/cv", "cover letter", "Master-Graduate", "mahirprcanovic@gmail.com", "Henry", "Cavill", "applied" },
                    { new Guid("7a491f86-4cc4-4cd7-9228-2286c10f1964"), "https://emilia.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Emilia", "Clarke", "applied" },
                    { new Guid("7ce59cd3-9454-4a00-8e6f-4a8ec490713c"), "https://github.com/asalcin3", "cover letter", "Master-Undergraduate", "adnasalcin@gmail.com", "Adna", "Salcin", "applied" },
                    { new Guid("b5cbeeb0-3abf-4967-97ce-eb308a2387c5"), "https://lewis.com/cv", "cover letter", "Doctor-Undergraduate", "mahirprcanovic@gmail.com", "Lewis", "Hamilton", "applied" },
                    { new Guid("be1f15d2-78c1-43b1-a5a5-e61c50f960cb"), "https://loremipsum.com", "cover letter", "HighSchool-Graduate", "mahirprcanovic@gmail.com", "Lorem", "Ipsum", "applied" },
                    { new Guid("eeb7e313-8e7d-4911-8c3c-4db365350e26"), "https://olivia.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Olivia", "Wilde", "applied" },
                    { new Guid("f196f98f-0645-426e-a951-f2d81113676f"), "https://john.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "John", "Doe", "applied" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8a3456-968d-450d-9d53-ec8ca286cf66", "AQAAAAEAACcQAAAAEFD8eIFSjmA9aOgYrfKdKpmSSQXbjjisEz3cMYGGeM6zvG/mwf2tMKpXR0mvaBE12w==", "0be3a31c-600a-4d19-98d2-097e633e443a" });
        }
    }
}
