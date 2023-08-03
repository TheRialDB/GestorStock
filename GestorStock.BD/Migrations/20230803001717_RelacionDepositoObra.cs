using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDepositoObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObraId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Obras_ObraId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_ObraId",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "ObraId",
                table: "Depositos");
        }
    }
}
