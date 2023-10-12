using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class cambios1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Ecosystems");

            migrationBuilder.AlterColumn<string>(
                name: "ThreatName_Value",
                table: "Threats",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AddColumn<string>(
                name: "ThreatDescription_Value",
                table: "Threats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName_Value",
                table: "Species",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AddColumn<string>(
                name: "SpeciesDescription_Value",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SpeciesName_MaxLength",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesName_MinLength",
                table: "Species",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "EcosystemName_Value",
                table: "Ecosystems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AddColumn<string>(
                name: "EcoDescription_Value",
                table: "Ecosystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EcosystemName_MaxLength",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EcosystemName_MinLength",
                table: "Ecosystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName_Value",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AlterColumn<string>(
                name: "ConservationName_Value",
                table: "Conservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ConservationName_MaxLength",
                table: "Conservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConservationName_MinLength",
                table: "Conservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreatDescription_MaxLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "ThreatDescription_MinLength",
                table: "Threats");

            migrationBuilder.DropColumn(
                name: "ThreatDescription_Value",
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
                name: "SpeciesDescription_Value",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesName_MaxLength",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SpeciesName_MinLength",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EcoDescription_MaxLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcoDescription_MinLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcoDescription_Value",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcosystemName_MaxLength",
                table: "Ecosystems");

            migrationBuilder.DropColumn(
                name: "EcosystemName_MinLength",
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
                name: "ConservationName_MinLength",
                table: "Conservation");

            migrationBuilder.AlterColumn<string>(
                name: "ThreatName_Value",
                table: "Threats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Threats",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName_Value",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Species",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EcosystemName_Value",
                table: "Ecosystems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Ecosystems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName_Value",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ConservationName_Value",
                table: "Conservation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
