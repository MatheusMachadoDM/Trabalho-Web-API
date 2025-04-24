using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelConsagradoAPI.Migrations
{
    /// <inheritdoc />
    public partial class ValidacoesParaCadastros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Hospedes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "Hospedes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Hospedes",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Hospedes");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Hospedes");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Hospedes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
