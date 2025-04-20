using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelConsagradoAPI.Migrations
{
    /// <inheritdoc />
    public partial class MakeHospedeReservaNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataCheckIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCheckOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantidadeAdultos = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeCriancas = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeQuartos = table.Column<int>(type: "INTEGER", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmailResponsavel = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneResponsavel = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospedes_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospedes_ReservaId",
                table: "Hospedes",
                column: "ReservaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospedes");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
