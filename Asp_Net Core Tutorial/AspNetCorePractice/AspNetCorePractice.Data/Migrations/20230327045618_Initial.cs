using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCorePractice.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "Email", "EndDate", "IsActive", "Room", "StartDate" },
                values: new object[,]
                {
                    { 1, "sabya9106@gmail.com", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "bombay.sangram@gmail.com", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "sabyasachi.patnaik@hotmail.com", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "abc@gmail.com", new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "xyz@gmail.com", new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "UK" },
                    { 3, "India" },
                    { 4, "France" },
                    { 5, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Country", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Sabyasachi" },
                    { 2, 2, 1, "Punyasloka" },
                    { 3, 3, 1, "Sangram" },
                    { 4, 4, 2, "Rasmi" },
                    { 5, 5, 2, "Adyasha" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "101", 1 },
                    { 2, "102", 1 },
                    { 3, "103", 1 },
                    { 4, "104", 1 },
                    { 5, "105", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
