using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineShop.Migrations
{
    public partial class initialCommitV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetail_Cart_CartId",
                table: "ShippingDetail");

            migrationBuilder.DropIndex(
                name: "IX_ShippingDetail_CartId",
                table: "ShippingDetail");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ShippingDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ShippingDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetail_CartId",
                table: "ShippingDetail",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetail_Cart_CartId",
                table: "ShippingDetail",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
