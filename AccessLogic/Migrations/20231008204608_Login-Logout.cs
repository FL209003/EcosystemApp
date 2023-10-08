using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class LoginLogout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Security",
                table: "Conservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Security",
                table: "Conservation");
        }
    }
}
