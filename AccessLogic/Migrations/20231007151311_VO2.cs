using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class VO2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesName_Value",
                table: "Species",
                column: "SpeciesName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ecosystems_EcosystemName_Value",
                table: "Ecosystems",
                column: "EcosystemName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName_Value",
                table: "Countries",
                column: "CountryName_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conservation_ConservationName_Value",
                table: "Conservation",
                column: "ConservationName_Value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Species_SpeciesName_Value",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Ecosystems_EcosystemName_Value",
                table: "Ecosystems");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryName_Value",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Conservation_ConservationName_Value",
                table: "Conservation");
        }
    }
}
