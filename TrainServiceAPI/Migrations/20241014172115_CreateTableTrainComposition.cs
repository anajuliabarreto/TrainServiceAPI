using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTrainComposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trens_Veiculos_VehicleModelsId",
                table: "Trens");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Trens_TrainId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_TrainId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Trens_VehicleModelsId",
                table: "Trens");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "VehicleModelsId",
                table: "Trens");

            migrationBuilder.CreateTable(
                name: "TremVeiculo",
                columns: table => new
                {
                    TremId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TremVeiculo", x => new { x.TremId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_TremVeiculo_Trens_TremId",
                        column: x => x.TremId,
                        principalTable: "Trens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TremVeiculo_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TremVeiculo_VeiculoId",
                table: "TremVeiculo",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TremVeiculo");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleModelsId",
                table: "Trens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TrainId",
                table: "Veiculos",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Trens_VehicleModelsId",
                table: "Trens",
                column: "VehicleModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trens_Veiculos_VehicleModelsId",
                table: "Trens",
                column: "VehicleModelsId",
                principalTable: "Veiculos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Trens_TrainId",
                table: "Veiculos",
                column: "TrainId",
                principalTable: "Trens",
                principalColumn: "Id");
        }
    }
}
