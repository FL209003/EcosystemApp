using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class ciclicFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosystems_Conservations_EcoConservationId",
                table: "Ecosystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Conservations_SpeciesConservationId",
                table: "Species");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosystems_Conservations_EcoConservationId",
                table: "Ecosystems",
                column: "EcoConservationId",
                principalTable: "Conservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Conservations_SpeciesConservationId",
                table: "Species",
                column: "SpeciesConservationId",
                principalTable: "Conservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosystems_Conservations_EcoConservationId",
                table: "Ecosystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Conservations_SpeciesConservationId",
                table: "Species");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecosystems_Conservations_EcoConservationId",
                table: "Ecosystems",
                column: "EcoConservationId",
                principalTable: "Conservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Conservations_SpeciesConservationId",
                table: "Species",
                column: "SpeciesConservationId",
                principalTable: "Conservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
