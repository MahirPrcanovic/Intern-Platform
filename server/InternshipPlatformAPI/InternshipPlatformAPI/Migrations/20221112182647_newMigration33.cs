using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipPlatformAPI.Migrations
{
    public partial class newMigration33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CV", "CoverLetter", "EducationLevel", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { new Guid("00464308-a505-4c1b-ab1b-8a5e3ab6b8a9"), "https://lewis.com/cv", "cover letter", "Doctor-Undergraduate", "mahirprcanovic@gmail.com", "Lewis", "Hamilton", "applied" },
                    { new Guid("0663a11a-735e-46da-8d6e-3fdca35d9c7d"), "https://github.com/MahirPrcanovic", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Mahir", "Prcanovic", "applied" },
                    { new Guid("0da91440-a1b1-409a-b166-15c758174302"), "https://tom.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Tom", "Hardy", "applied" },
                    { new Guid("3cfdc753-0ab7-45e4-a982-97c8800744ee"), "https://ryan.com/cv", "cover letter", "College-Undergraduate", "mahirprcanovic@gmail.com", "Ryan", "Reynolds", "applied" },
                    { new Guid("3eaac498-aafb-41a1-b758-ddbff0eb3641"), "https://jack.com/cv", "cover letter", "Doctor-Graduate", "mahirprcanovic@gmail.com", "Jack", "Whitehall", "applied" },
                    { new Guid("5624333e-b193-4793-a544-9c6e7fa196a4"), "https://john.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "John", "Doe", "applied" },
                    { new Guid("57098063-5a38-4a97-97e6-62371a4f1bf6"), "https://loremipsum.com", "cover letter", "HighSchool-Graduate", "mahirprcanovic@gmail.com", "Lorem", "Ipsum", "applied" },
                    { new Guid("640635eb-ac24-456d-a65e-bd55eda8aeff"), "https://emilia.com/cv", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Emilia", "Clarke", "applied" },
                    { new Guid("729b84fb-41d0-4e0c-acc1-69847fb00b84"), "https://olivia.com/cv", "cover letter", "Master-Undergraduate", "mahirprcanovic@gmail.com", "Olivia", "Wilde", "applied" },
                    { new Guid("7754156a-ec04-4e35-839b-84d4102feb16"), "https://mick.com", "cover letter", "College-Graduate", "mahirprcanovic@gmail.com", "Mick", "Schumacher", "applied" },
                    { new Guid("a4efcaf4-3fe2-49f0-a8ae-10b8370894d8"), "https://github.com/asalcin3", "cover letter", "Master-Undergraduate", "adnasalcin@gmail.com", "Adna", "Salcin", "applied" },
                    { new Guid("fc90edd0-7be8-4101-a103-dbb2c29780bb"), "https://henry.com/cv", "cover letter", "Master-Graduate", "mahirprcanovic@gmail.com", "Henry", "Cavill", "applied" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b4e0601-f811-4f28-80e5-baa7c5f0741e", "AQAAAAEAACcQAAAAEP/l6Dz5NnvMf/rS5STPSQZJodfxbWeIoKoWylUIlbZ7Ak1D9wFUqb63I27bdh0AnQ==", "db7c2303-c3de-44cd-9c3f-a29584b9a3e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("00464308-a505-4c1b-ab1b-8a5e3ab6b8a9"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("0663a11a-735e-46da-8d6e-3fdca35d9c7d"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("0da91440-a1b1-409a-b166-15c758174302"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3cfdc753-0ab7-45e4-a982-97c8800744ee"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("3eaac498-aafb-41a1-b758-ddbff0eb3641"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("5624333e-b193-4793-a544-9c6e7fa196a4"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("57098063-5a38-4a97-97e6-62371a4f1bf6"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("640635eb-ac24-456d-a65e-bd55eda8aeff"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("729b84fb-41d0-4e0c-acc1-69847fb00b84"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("7754156a-ec04-4e35-839b-84d4102feb16"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("a4efcaf4-3fe2-49f0-a8ae-10b8370894d8"));

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: new Guid("fc90edd0-7be8-4101-a103-dbb2c29780bb"));

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
    }
}
