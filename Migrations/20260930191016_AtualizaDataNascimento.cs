using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaDataNascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
