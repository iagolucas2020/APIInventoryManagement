using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIInventoryManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeAtributo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Stocks",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "Amount");
        }
    }
}
