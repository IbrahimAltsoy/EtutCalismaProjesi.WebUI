using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtutCalismaProjesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 29, 18, 45, 54, 469, DateTimeKind.Local).AddTicks(7854));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2022, 12, 28, 20, 52, 58, 614, DateTimeKind.Local).AddTicks(7724));
        }
    }
}
