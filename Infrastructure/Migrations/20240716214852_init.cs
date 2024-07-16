using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalPaticipant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "TotalPaticipant", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 16, 21, 48, 50, 324, DateTimeKind.Utc).AddTicks(5337), null, "Angular 18", 0, null },
                    { 2, new DateTime(2024, 7, 16, 21, 48, 50, 324, DateTimeKind.Utc).AddTicks(5339), null, "Full Stack Web Development", 0, null },
                    { 3, new DateTime(2024, 7, 16, 21, 48, 50, 324, DateTimeKind.Utc).AddTicks(5341), null, "Database Organization", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
