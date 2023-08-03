using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionNotaPedidoRemito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotaPedidoRemito_Remitos_Remitosid",
                        column: x => x.Remitosid,
                        principalTable: "Remitos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaPedidoRemito_Remitosid",
                table: "NotaPedidoRemito",
                column: "Remitosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaPedidoRemito");
        }
    }
}
