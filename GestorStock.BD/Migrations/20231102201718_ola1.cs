using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class ola1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductoId",
                table: "Stocks",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Productos_ProductoId",
                table: "Stocks",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Productos_ProductoId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductoId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Stocks");
        }
    }
}
