using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDetallePedidoNotaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotaPedidoId",
                table: "DetallePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_NotaPedidoId",
                table: "DetallePedidos",
                column: "NotaPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos",
                column: "NotaPedidoId",
                principalTable: "NotaPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_NotaPedidoId",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "NotaPedidoId",
                table: "DetallePedidos");
        }
    }
}
