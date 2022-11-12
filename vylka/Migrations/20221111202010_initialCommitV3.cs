using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vylka.Migrations
{
    public partial class initialCommitV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_CartUserId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "CartUserId",
                table: "Cart",
                newName: "CartUserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CartUserId",
                table: "Cart",
                newName: "IX_Cart_CartUserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_CartUserIdId",
                table: "Cart",
                column: "CartUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_CartUserIdId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "CartUserIdId",
                table: "Cart",
                newName: "CartUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CartUserIdId",
                table: "Cart",
                newName: "IX_Cart_CartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_CartUserId",
                table: "Cart",
                column: "CartUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
