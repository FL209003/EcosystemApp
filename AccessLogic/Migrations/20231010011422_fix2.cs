using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "WeightRangeMin",
                table: "Species",
                newName: "Min weight");

            migrationBuilder.RenameColumn(
                name: "WeightRangeMax",
                table: "Species",
                newName: "Max weight");

            migrationBuilder.RenameColumn(
                name: "LongRangeAdultMin",
                table: "Species",
                newName: "Min length");

            migrationBuilder.RenameColumn(
                name: "LongRangeAdultMax",
                table: "Species",
                newName: "Max length");

            migrationBuilder.RenameColumn(
                name: "CientificName",
                table: "Species",
                newName: "Cientific name");

            migrationBuilder.RenameColumn(
                name: "GeoDetails",
                table: "Ecosystems",
                newName: "Geographic details");

            migrationBuilder.RenameColumn(
                name: "Alpha3",
                table: "Countries",
                newName: "Alpha 3 code");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "Min weight",
                table: "Species",
                newName: "WeightRangeMin");

            migrationBuilder.RenameColumn(
                name: "Min length",
                table: "Species",
                newName: "LongRangeAdultMin");

            migrationBuilder.RenameColumn(
                name: "Max weight",
                table: "Species",
                newName: "WeightRangeMax");

            migrationBuilder.RenameColumn(
                name: "Max length",
                table: "Species",
                newName: "LongRangeAdultMax");

            migrationBuilder.RenameColumn(
                name: "Cientific name",
                table: "Species",
                newName: "CientificName");

            migrationBuilder.RenameColumn(
                name: "Geographic details",
                table: "Ecosystems",
                newName: "GeoDetails");

            migrationBuilder.RenameColumn(
                name: "Alpha 3 code",
                table: "Countries",
                newName: "Alpha3");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
