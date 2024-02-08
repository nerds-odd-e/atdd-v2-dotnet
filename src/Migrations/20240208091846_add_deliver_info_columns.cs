using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atdd_v2_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class add_deliver_info_columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "deliver_no",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "delivered_at",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliver_no",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "delivered_at",
                table: "orders");
        }
    }
}
