using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class @params : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Conservation",
                table: "Conservation");

            migrationBuilder.DropColumn(
                name: "ThreatDescription_MaxLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "ThreatDescription_MinLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "ThreatName_MaxLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "ThreatName_MinLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "SpeciesDescription_MaxLength",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesDescription_MinLength",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesName_MaxLength",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EcoDescription_MaxLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcoDescription_MinLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcosystemName_MaxLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "CountryName_MaxLength",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryName_MinLength",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ConservationName_MaxLength",
                table: "Conservation");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Conservation");

            migrationBuilder.RenameTable(
                name: "Conservation",
                newName: "Conservations");

            migrationBuilder.RenameColumn(
                name: "SpeciesName_MinLength",
                table: "Species",
                newName: "SpeciesConservationId");

            migrationBuilder.RenameColumn(
                name: "EcosystemName_MinLength",
                table: "Ecosystems",
                newName: "EcoConservationId");

            migrationBuilder.RenameColumn(
                name: "Rango de seguridad",
                table: "Conservations",
                newName: "Rango de conservación mínimo");

            migrationBuilder.RenameColumn(
                name: "ConservationName_MinLength",
                table: "Conservations",
                newName: "Rango de conservación máximo");

            migrationBuilder.RenameIndex(
                name: "IX_Conservation_ConservationName_Value",
                table: "Conservations",
                newName: "IX_Conservations_ConservationName_Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conservations",
                table: "Conservations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Limits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesConservationId",
                table: "Species",
                column: "SpeciesConservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosystems_EcoConservationId",
                table: "Ecosystems",
                column: "EcoConservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Limits_Name",
                table: "Limits",
                column: "Name",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecosystems_Conservations_EcoConservationId",
                table: "Ecosystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Conservations_SpeciesConservationId",
                table: "Species");

            migrationBuilder.DropTable(
                name: "Limits");

            migrationBuilder.DropIndex(
                name: "IX_Species_SpeciesConservationId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Ecosystems_EcoConservationId",
                table: "Ecosystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conservations",
                table: "Conservations");

            migrationBuilder.RenameTable(
                name: "Conservations",
                newName: "Conservation");

            migrationBuilder.RenameColumn(
                name: "SpeciesConservationId",
                table: "Species",
                newName: "SpeciesName_MinLength");

            migrationBuilder.RenameColumn(
                name: "EcoConservationId",
                table: "Ecosystems",
                newName: "EcosystemName_MinLength");

            migrationBuilder.RenameColumn(
                name: "Rango de conservación mínimo",
                table: "Conservation",
                newName: "Rango de seguridad");

            migrationBuilder.RenameColumn(
                name: "Rango de conservación máximo",
                table: "Conservation",
                newName: "ConservationName_MinLength");

            migrationBuilder.RenameIndex(
                name: "IX_Conservations_ConservationName_Value",
                table: "Conservation",
                newName: "IX_Conservation_ConservationName_Value");

            migrationBuilder.AddColumn<int>(
                name: "ThreatDescription_MaxLength",
                table: "Threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreatDescription_MinLength",
                table: "Threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreatName_MaxLength",
                table: "Threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreatName_MinLength",
                table: "Threats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesDescription_MaxLength",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesDescription_MinLength",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesName_MaxLength",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EcoDescription_MaxLength",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EcoDescription_MinLength",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EcosystemName_MaxLength",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryName_MaxLength",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryName_MinLength",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConservationName_MaxLength",
                table: "Conservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Conservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conservation",
                table: "Conservation",
                column: "Id");
        }
    }
}
