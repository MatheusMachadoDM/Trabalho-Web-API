using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoEntreTabelasECapacidadeEmQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Quartos",
                newName: "Capacidade");

            migrationBuilder.AddColumn<int>(
                name: "QuartoId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_QuartoId",
                table: "Reservas",
                column: "QuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_QuartoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "QuartoId",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Capacidade",
                table: "Quartos",
                newName: "Type");
        }
    }
}
