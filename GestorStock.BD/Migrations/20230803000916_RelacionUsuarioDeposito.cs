using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUsuarioDeposito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositoUsuario_Usuarios_Usuariosid",
                        column: x => x.Usuariosid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositoUsuario_Usuariosid",
                table: "DepositoUsuario",
                column: "Usuariosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositoUsuario");
        }
    }
}
