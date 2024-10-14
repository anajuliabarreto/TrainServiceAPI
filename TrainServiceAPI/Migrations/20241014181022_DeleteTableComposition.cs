using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableComposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TremVeiculo");

            migrationBuilder.CreateTable(
                name: "TrainModelsVehicleModels",
                columns: table => new
                {
                    TrensId = table.Column<int>(type: "int", nullable: false),
                    VeiculosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainModelsVehicleModels", x => new { x.TrensId, x.VeiculosId });
                    table.ForeignKey(
                        name: "FK_TrainModelsVehicleModels_Trens_TrensId",
                        column: x => x.TrensId,
                        principalTable: "Trens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainModelsVehicleModels_Veiculos_VeiculosId",
                        column: x => x.VeiculosId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainModelsVehicleModels_VeiculosId",
                table: "TrainModelsVehicleModels",
                column: "VeiculosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainModelsVehicleModels");

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
    }
}
