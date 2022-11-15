using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vylka.Migrations
{
    public partial class initialCommitV9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItem");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "ShippingDetail",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "ShippingDetail",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "CartItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
