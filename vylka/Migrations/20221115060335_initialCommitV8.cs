using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vylka.Migrations
{
    public partial class initialCommitV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "CartItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItem");
        }
    }
}
