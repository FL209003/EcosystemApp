using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Ecosystems_EcosystemId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_EcosystemId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EcosystemId",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Threats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LongRangeAdultMax",
                table: "Species",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LongRangeAdultMin",
                table: "Species",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightRangeMax",
                table: "Species",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightRangeMin",
                table: "Species",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "EcosystemSpecies",
                columns: table => new
                {
                    HabitatsId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosystemSpecies", x => new { x.HabitatsId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_EcosystemSpecies_Ecosystems_HabitatsId",
                        column: x => x.HabitatsId,
                        principalTable: "Ecosystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosystemSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Threats_SpeciesId",
                table: "Threats",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosystemSpecies_SpeciesId",
                table: "EcosystemSpecies",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Threats_Species_SpeciesId",
                table: "Threats",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threats_Species_SpeciesId",
                table: "Threats");

            migrationBuilder.DropTable(
                name: "EcosystemSpecies");

            migrationBuilder.DropIndex(
                name: "IX_Threats_SpeciesId",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "LongRangeAdultMax",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "LongRangeAdultMin",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "WeightRangeMax",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "WeightRangeMin",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "EcosystemId",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_EcosystemId",
                table: "Species",
                column: "EcosystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Ecosystems_EcosystemId",
                table: "Species",
                column: "EcosystemId",
                principalTable: "Ecosystems",
                principalColumn: "Id");
        }
    }
}
