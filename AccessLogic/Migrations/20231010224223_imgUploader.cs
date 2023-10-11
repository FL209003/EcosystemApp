using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class imgUploader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosystemSpecies_Ecosystems_HabitatsId",
                table: "EcosystemSpecies");

            migrationBuilder.RenameColumn(
                name: "HabitatsId",
                table: "EcosystemSpecies",
                newName: "EcosystemsId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ecosystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Alpha 3 code",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Alpha 3 code",
                table: "Countries",
                column: "Alpha 3 code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EcosystemSpecies_Ecosystems_EcosystemsId",
                table: "EcosystemSpecies",
                column: "EcosystemsId",
                principalTable: "Ecosystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcosystemSpecies_Ecosystems_EcosystemsId",
                table: "EcosystemSpecies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Alpha 3 code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ecosystems");

            migrationBuilder.RenameColumn(
                name: "EcosystemsId",
                table: "EcosystemSpecies",
                newName: "HabitatsId");

            migrationBuilder.AlterColumn<string>(
                name: "Alpha 3 code",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_EcosystemSpecies_Ecosystems_HabitatsId",
                table: "EcosystemSpecies",
                column: "HabitatsId",
                principalTable: "Ecosystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
