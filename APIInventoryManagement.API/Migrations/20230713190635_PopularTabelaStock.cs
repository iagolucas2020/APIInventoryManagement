using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIInventoryManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Insert into Stocks(Quantity, Date, Location, MerchandiseId) Values('20', '{DateTime.Now}', 'China', '1')");
            migrationBuilder.Sql($"Insert into Stocks(Quantity, Date, Location, MerchandiseId) Values('30', '{DateTime.Now}', 'EUA', '2')");
            migrationBuilder.Sql($"Insert into Stocks(Quantity, Date, Location, MerchandiseId) Values('40', '{DateTime.Now}', 'Brasil', '3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Stocks");
        }
    }
}
