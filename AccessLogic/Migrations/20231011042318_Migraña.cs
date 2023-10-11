using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class Migraña : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Threats",
                newName: "Descripción");

            migrationBuilder.RenameColumn(
                name: "Danger",
                table: "Threats",
                newName: "Nivel de peligrosidad");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Ecosystems",
                newName: "Imagen");

            migrationBuilder.RenameColumn(
                name: "Geographic details",
                table: "Ecosystems",
                newName: "Ubicación");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ecosystems",
                newName: "Descripción");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Ecosystems",
                newName: "Área");

            migrationBuilder.RenameColumn(
                name: "Alpha 3 code",
                table: "Countries",
                newName: "Código alfa-3");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Alpha 3 code",
                table: "Countries",
                newName: "IX_Countries_Código alfa-3");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Conservation",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Security",
                table: "Conservation",
                newName: "Rango de seguridad");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha de registro",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ThreatName_Value",
                table: "Threats",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName_Value",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "EcosystemName_Value",
                table: "Ecosystems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName_Value",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "EcosystemId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConservationName_Value",
                table: "Conservation",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_EcosystemId",
                table: "Countries",
                column: "EcosystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Ecosystems_EcosystemId",
                table: "Countries",
                column: "EcosystemId",
                principalTable: "Ecosystems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Ecosystems_EcosystemId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_EcosystemId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Fecha de registro",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EcosystemId",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Nivel de peligrosidad",
                table: "Threats",
                newName: "Danger");

            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Threats",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Área",
                table: "Ecosystems",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "Ubicación",
                table: "Ecosystems",
                newName: "Geographic details");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Ecosystems",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Ecosystems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Código alfa-3",
                table: "Countries",
                newName: "Alpha 3 code");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Código alfa-3",
                table: "Countries",
                newName: "IX_Countries_Alpha 3 code");

            migrationBuilder.RenameColumn(
                name: "Rango de seguridad",
                table: "Conservation",
                newName: "Security");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Conservation",
                newName: "State");

            migrationBuilder.AlterColumn<string>(
                name: "ThreatName_Value",
                table: "Threats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName_Value",
                table: "Species",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EcosystemName_Value",
                table: "Ecosystems",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName_Value",
                table: "Countries",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ConservationName_Value",
                table: "Conservation",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
