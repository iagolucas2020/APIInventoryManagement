using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIInventoryManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabelaMerchandise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"Insert into Merchandises(Name, RegisterNumber, Manufacturer, Type, Description) Values('Bola', '2233', 'Nike', 'Nylon', 'Bola de nylon fabricada na china')");
            migrationBuilder.Sql($"Insert into Merchandises(Name, RegisterNumber, Manufacturer, Type, Description) Values('Notebook', '1125', 'Asus', 'Plastico', 'Notebook gamer')");
            migrationBuilder.Sql($"Insert into Merchandises(Name, RegisterNumber, Manufacturer, Type, Description) Values('Caneta', '1030', 'Bic', 'Plastico', 'Canetas azuis')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Merchandises");
        }
    }
}
