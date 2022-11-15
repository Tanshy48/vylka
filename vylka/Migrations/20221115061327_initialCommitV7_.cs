using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vylka.Migrations
{
    public partial class initialCommitV7_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetail_Cart_CartId",
                table: "ShippingDetail");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShippingDetail",
                newName: "CartIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingDetail_CartId",
                table: "ShippingDetail",
                newName: "IX_ShippingDetail_CartIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetail_CartItem_CartIdId",
                table: "ShippingDetail",
                column: "CartIdId",
                principalTable: "CartItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetail_CartItem_CartIdId",
                table: "ShippingDetail");

            migrationBuilder.RenameColumn(
                name: "CartIdId",
                table: "ShippingDetail",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingDetail_CartIdId",
                table: "ShippingDetail",
                newName: "IX_ShippingDetail_CartId");

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
