using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTapSavis_API.Migrations
{
    public partial class _24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "ProductItems",
                newName: "PriceAfterReduction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceAfterReduction",
                table: "ProductItems",
                newName: "PurchasePrice");
        }
    }
}
