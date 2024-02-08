using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atdd_v2_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class add_total : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "orders",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "orders");
        }
    }
}
