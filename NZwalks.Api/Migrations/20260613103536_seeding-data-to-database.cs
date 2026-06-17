using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatatodatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6246e4b9-da4f-4e83-a778-51ac742524e2"), "Easy" },
                    { new Guid("79a6253b-eb78-4168-988d-611a62e2ed40"), "Hard" },
                    { new Guid("84b58f3c-2e20-4809-8a5d-2a1d1c55d635"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1c43f593-c3fc-4d94-9a49-73081532ce9f"), "TN56", "Erode", "https//Erode.com" },
                    { new Guid("869af7ca-0ccc-455f-b934-1bf0524c38c5"), "TN56", "Perundurai", "https//Perundurai.com" },
                    { new Guid("969cf319-f21a-4ff4-835b-808cb932186f"), "TN37", "Coimbatore", "https//Coimbatore.com" },
                    { new Guid("bfa37282-a3df-47da-bb43-6eee646c023b"), "TN58", "Tripur", "https//Tripur.com" },
                    { new Guid("c4161cb1-52ba-413d-a8f4-bd2800efb54d"), "TN36", "Gobi", "https//gobi.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6246e4b9-da4f-4e83-a778-51ac742524e2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("79a6253b-eb78-4168-988d-611a62e2ed40"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("84b58f3c-2e20-4809-8a5d-2a1d1c55d635"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1c43f593-c3fc-4d94-9a49-73081532ce9f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("869af7ca-0ccc-455f-b934-1bf0524c38c5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("969cf319-f21a-4ff4-835b-808cb932186f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bfa37282-a3df-47da-bb43-6eee646c023b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4161cb1-52ba-413d-a8f4-bd2800efb54d"));
        }
    }
}
