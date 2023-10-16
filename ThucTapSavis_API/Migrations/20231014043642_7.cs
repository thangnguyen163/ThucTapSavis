using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTapSavis_API.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Discount_Conditions",
                table: "Promotions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discount_Conditions",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
