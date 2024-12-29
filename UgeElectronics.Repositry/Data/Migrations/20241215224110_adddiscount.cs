using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UgeElectronics.Repositry.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");
        }
    }
}
