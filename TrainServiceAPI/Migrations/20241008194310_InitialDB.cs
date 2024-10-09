using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalDeOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalDeDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTrem = table.Column<int>(type: "int", nullable: false),
                    Ferrovia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataHoraPartida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trens");
        }
    }
}
