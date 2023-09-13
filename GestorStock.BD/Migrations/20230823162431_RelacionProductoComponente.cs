using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionProductoComponente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoUsuario_Depositos_Depositosid",
                table: "DepositoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                table: "DepositoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidoRemito_NotaPedidos_NotaPedidosid",
                table: "NotaPedidoRemito");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                table: "NotaPedidoRemito");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidos_Estados_EstadoId",
                table: "NotaPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Depositos_DepositoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "ProductoComponentes",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ComponenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoComponentes", x => new { x.ProductoId, x.ComponenteId });
                    table.ForeignKey(
                        name: "FK_ProductoComponentes_Componentes_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoComponentes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoComponentes_ComponenteId",
                table: "ProductoComponentes",
                column: "ComponenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoUsuario_Depositos_Depositosid",
                table: "DepositoUsuario",
                column: "Depositosid",
                principalTable: "Depositos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                table: "DepositoUsuario",
                column: "Usuariosid",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos",
                column: "NotaPedidoId",
                principalTable: "NotaPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidoRemito_NotaPedidos_NotaPedidosid",
                table: "NotaPedidoRemito",
                column: "NotaPedidosid",
                principalTable: "NotaPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                table: "NotaPedidoRemito",
                column: "Remitosid",
                principalTable: "Remitos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidos_Estados_EstadoId",
                table: "NotaPedidos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Depositos_DepositoId",
                table: "Productos",
                column: "DepositoId",
                principalTable: "Depositos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoUsuario_Depositos_Depositosid",
                table: "DepositoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                table: "DepositoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidoRemito_NotaPedidos_NotaPedidosid",
                table: "NotaPedidoRemito");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                table: "NotaPedidoRemito");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaPedidos_Estados_EstadoId",
                table: "NotaPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Depositos_DepositoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "ProductoComponentes");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoUsuario_Depositos_Depositosid",
                table: "DepositoUsuario",
                column: "Depositosid",
                principalTable: "Depositos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                table: "DepositoUsuario",
                column: "Usuariosid",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                table: "DetallePedidos",
                column: "NotaPedidoId",
                principalTable: "NotaPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Productos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidoRemito_NotaPedidos_NotaPedidosid",
                table: "NotaPedidoRemito",
                column: "NotaPedidosid",
                principalTable: "NotaPedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                table: "NotaPedidoRemito",
                column: "Remitosid",
                principalTable: "Remitos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaPedidos_Estados_EstadoId",
                table: "NotaPedidos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Estados_EstadoId",
                table: "Obras",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Depositos_DepositoId",
                table: "Productos",
                column: "DepositoId",
                principalTable: "Depositos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Unidades_UnidadId",
                table: "Productos",
                column: "UnidadId",
                principalTable: "Unidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
