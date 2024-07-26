using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorparticipantentityproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPaticipants",
                table: "Courses",
                newName: "TotalParticipants");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(834), new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(888), new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 7, 25, 9, 6, 10, 582, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 7, 6, 10, 582, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 7, 6, 10, 582, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 25, 7, 6, 10, 582, DateTimeKind.Utc).AddTicks(2566));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalParticipants",
                table: "Courses",
                newName: "TotalPaticipants");

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 22, 23, 2, 3, 835, DateTimeKind.Local).AddTicks(6057), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 22, 23, 2, 3, 835, DateTimeKind.Local).AddTicks(6104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplyAt", "CreatedDate" },
                values: new object[] { new DateTime(2024, 7, 22, 23, 2, 3, 835, DateTimeKind.Local).AddTicks(6107), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 21, 2, 3, 835, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 21, 2, 3, 835, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 22, 21, 2, 3, 835, DateTimeKind.Utc).AddTicks(7696));
        }
    }
}
