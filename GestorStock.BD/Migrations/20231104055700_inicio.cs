using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEstado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Remitos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remitos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUnidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    simbolo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NotaPedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    emisor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    receptor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaPedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotaPedidos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreObra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obras_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaPedidoRemito",
                columns: table => new
                {
                    NotaPedidosid = table.Column<int>(type: "int", nullable: false),
                    Remitosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaPedidoRemito", x => new { x.NotaPedidosid, x.Remitosid });
                    table.ForeignKey(
                        name: "FK_NotaPedidoRemito_NotaPedidos_NotaPedidosid",
                        column: x => x.NotaPedidosid,
                        principalTable: "NotaPedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                        column: x => x.Remitosid,
                        principalTable: "Remitos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreDeposito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Depositos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Componentes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepositoUsuario",
                columns: table => new
                {
                    Depositosid = table.Column<int>(type: "int", nullable: false),
                    Usuariosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositoUsuario", x => new { x.Depositosid, x.Usuariosid });
                    table.ForeignKey(
                        name: "FK_DepositoUsuario_Depositos_Depositosid",
                        column: x => x.Depositosid,
                        principalTable: "Depositos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                        column: x => x.Usuariosid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    DepositoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stocks_Depositos_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "Depositos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoComponentes",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ComponenteId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", maxLength: 40, nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    NotaPedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_NotaPedidos_NotaPedidoId",
                        column: x => x.NotaPedidoId,
                        principalTable: "NotaPedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ProductoId",
                table: "Componentes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoUsuario_Usuariosid",
                table: "DepositoUsuario",
                column: "Usuariosid");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_NotaPedidoId",
                table: "DetallePedidos",
                column: "NotaPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_StockId",
                table: "DetallePedidos",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaPedidoRemito_Remitosid",
                table: "NotaPedidoRemito",
                column: "Remitosid");

            migrationBuilder.CreateIndex(
                name: "IX_NotaPedidos_EstadoId",
                table: "NotaPedidos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EstadoId",
                table: "Obras",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoComponentes_ComponenteId",
                table: "ProductoComponentes",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnidadId",
                table: "Productos",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_DepositoId",
                table: "Stocks",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductoId",
                table: "Stocks",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositoUsuario");

            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "NotaPedidoRemito");

            migrationBuilder.DropTable(
                name: "ProductoComponentes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "NotaPedidos");

            migrationBuilder.DropTable(
                name: "Remitos");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
