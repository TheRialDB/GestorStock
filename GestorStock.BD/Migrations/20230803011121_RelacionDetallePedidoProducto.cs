using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDetallePedidoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DetallePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_ProductoId",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetallePedidos");
        }
    }
}
