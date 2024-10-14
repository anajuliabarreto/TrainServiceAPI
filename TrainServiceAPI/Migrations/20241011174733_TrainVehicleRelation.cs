using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class TrainVehicleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleModelsId",
                table: "Trens",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trens_Veiculos_VehicleModelsId",
                table: "Trens");

            migrationBuilder.DropIndex(
                name: "IX_Trens_VehicleModelsId",
                table: "Trens");

            migrationBuilder.DropColumn(
                name: "VehicleModelsId",
                table: "Trens");
        }
    }
}
