using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLotDal_Core2.Migrations
{
    public partial class AddRelationalshipManyToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Inventory_CarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustId",
                table: "Order",
                newName: "IX_Order_CustId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CarId",
                table: "Order",
                newName: "IX_Order_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Inventory_CarId",
                table: "Order",
                column: "CarId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customers_CustId",
                table: "Order",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Inventory_CarId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customers_CustId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustId",
                table: "Orders",
                newName: "IX_Orders_CustId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CarId",
                table: "Orders",
                newName: "IX_Orders_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Inventory_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustId",
                table: "Orders",
                column: "CustId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
