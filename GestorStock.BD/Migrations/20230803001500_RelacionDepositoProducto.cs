using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorStock.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDepositoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Depositos_Depositoid",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_Depositoid",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "Depositoid",
                table: "Depositos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Depositoid",
                table: "Depositos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_Depositoid",
                table: "Depositos",
                column: "Depositoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Depositos_Depositoid",
                table: "Depositos",
                column: "Depositoid",
                principalTable: "Depositos",
                principalColumn: "id");
        }
    }
}
