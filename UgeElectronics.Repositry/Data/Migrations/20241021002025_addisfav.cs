using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UgeElectronics.Repositry.Data.Migrations
{
    /// <inheritdoc />
    public partial class addisfav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavourite",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavourite",
                table: "Products");
        }
    }
}
