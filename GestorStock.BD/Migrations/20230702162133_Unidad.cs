using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class Unidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Productos_produtoID",
                table: "DetallePedidos");

            migrationBuilder.RenameColumn(
                name: "produtoID",
                table: "DetallePedidos",
                newName: "productoID");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePedidos_produtoID",
                table: "DetallePedidos",
                newName: "IX_DetallePedidos_productoID");

            migrationBuilder.AlterColumn<string>(
                name: "nombreUnidad",
                table: "Unidades",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Productos_productoID",
                table: "DetallePedidos",
                column: "productoID",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Productos_productoID",
                table: "DetallePedidos");

            migrationBuilder.RenameColumn(
                name: "productoID",
                table: "DetallePedidos",
                newName: "produtoID");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePedidos_productoID",
                table: "DetallePedidos",
                newName: "IX_DetallePedidos_produtoID");

            migrationBuilder.AlterColumn<string>(
                name: "nombreUnidad",
                table: "Unidades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Productos_produtoID",
                table: "DetallePedidos",
                column: "produtoID",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
