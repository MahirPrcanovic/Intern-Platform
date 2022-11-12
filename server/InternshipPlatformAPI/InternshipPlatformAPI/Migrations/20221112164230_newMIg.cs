using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPlatformAPI.Migrations
{
    public partial class newMIg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SelectionId",
                table: "Comments");

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

            migrationBuilder.DropColumn(
                name: "SelectionId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { new Guid("34b7fdef-3b7e-4c92-8af2-2c247ee35a73"), "https://tom.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Tom", "Hardy", "applied" },
                    { new Guid("61a2bd99-3ce8-44ff-b042-b5c246653224"), "https://jack.com/cv", "cover letter", "Doctor-Graduate", "mahirprcanovic@gmail.com", "Jack", "Whitehall", "applied" },
                    { new Guid("67042e3b-aeb0-4deb-a875-c3a1839bd1cd"), "https://github.com/asalcin3", "cover letter", "Master-Undergraduate", "adnasalcin@gmail.com", "Adna", "Salcin", "applied" },
                    { new Guid("80462afb-db4d-4496-bd52-02d20b1f23e2"), "https://lewis.com/cv", "cover letter", "Doctor-Undergraduate", "mahirprcanovic@gmail.com", "Lewis", "Hamilton", "applied" },
                    { new Guid("9df4a627-b548-4434-9aee-d4be08113802"), "https://olivia.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Olivia", "Wilde", "applied" },
                    { new Guid("ba586cf3-3cc1-4beb-8307-6f4fb965da3e"), "https://loremipsum.com", "cover letter", "HighSchool-Graduate", "mahirprcanovic@gmail.com", "Lorem", "Ipsum", "applied" },
                    { new Guid("d25de3b8-81c0-4c00-8646-4c919adaa812"), "https://john.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "John", "Doe", "applied" },
                    { new Guid("d377fc89-a37b-469f-b309-1ea9ad560cd2"), "https://ryan.com/cv", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Ryan", "Reynolds", "applied" },
                    { new Guid("dac811f8-3f3b-46aa-b76d-a4615c7da8a8"), "https://github.com/MahirPrcanovic", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" },
                    { new Guid("e3d1b2ac-afd9-4b52-9d29-5f1d280d9e7e"), "https://emilia.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Emilia", "Clarke", "applied" },
                    { new Guid("f12e1044-9f09-44e2-a28b-442f21ae4817"), "https://mick.com", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Mick", "Schumacher", "applied" },
                    { new Guid("f366ebc7-6f3e-4c23-93ec-76c802b8265b"), "https://henry.com/cv", "cover letter", "Master-Graduate", "mahirprcanovic@gmail.com", "Henry", "Cavill", "applied" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8c7d6e9-586d-44ab-b070-76d6c357d5e9", "AQAAAAEAACcQAAAAENvOvKajSsgyIgv7iT1TTq+nxezXeRVGBYdt9VU1Cph2x5sjxhmRgNHZ8fpJwkW1FQ==", "e53d549f-a392-49f8-9c2e-7c30a37ea754" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("34b7fdef-3b7e-4c92-8af2-2c247ee35a73"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("61a2bd99-3ce8-44ff-b042-b5c246653224"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("67042e3b-aeb0-4deb-a875-c3a1839bd1cd"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("80462afb-db4d-4496-bd52-02d20b1f23e2"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("9df4a627-b548-4434-9aee-d4be08113802"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("ba586cf3-3cc1-4beb-8307-6f4fb965da3e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("d25de3b8-81c0-4c00-8646-4c919adaa812"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("d377fc89-a37b-469f-b309-1ea9ad560cd2"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("dac811f8-3f3b-46aa-b76d-a4615c7da8a8"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("e3d1b2ac-afd9-4b52-9d29-5f1d280d9e7e"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("f12e1044-9f09-44e2-a28b-442f21ae4817"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("f366ebc7-6f3e-4c23-93ec-76c802b8265b"));

            migrationBuilder.AddColumn<Guid>(
                name: "SelectionId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SelectionId",
                table: "Comments",
                column: "SelectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Selections_SelectionId",
                table: "Comments",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id");
        }
    }
}
