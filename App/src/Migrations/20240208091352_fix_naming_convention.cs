using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atdd_v2_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class fix_naming_convention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "order_lines");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "order_lines",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "order_lines",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "order_lines",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "order_lines",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "order_lines",
                newName: "item_name");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "order_lines",
                newName: "IX_order_lines_order_id");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "orders",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RecipientName",
                table: "orders",
                newName: "recipient_name");

            migrationBuilder.RenameColumn(
                name: "RecipientMobile",
                table: "orders",
                newName: "recipient_mobile");

            migrationBuilder.RenameColumn(
                name: "RecipientAddress",
                table: "orders",
                newName: "recipient_address");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "orders",
                newName: "product_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_lines",
                table: "order_lines",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_lines_orders_order_id",
                table: "order_lines",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_lines_orders_order_id",
                table: "order_lines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_lines",
                table: "order_lines");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "order_lines",
                newName: "OrderLine");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Order",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "recipient_name",
                table: "Order",
                newName: "RecipientName");

            migrationBuilder.RenameColumn(
                name: "recipient_mobile",
                table: "Order",
                newName: "RecipientMobile");

            migrationBuilder.RenameColumn(
                name: "recipient_address",
                table: "Order",
                newName: "RecipientAddress");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Order",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderLine",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderLine",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrderLine",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderLine",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "item_name",
                table: "OrderLine",
                newName: "ItemName");

            migrationBuilder.RenameIndex(
                name: "IX_order_lines_order_id",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
