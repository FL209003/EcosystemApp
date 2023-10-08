using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessLogic.Migrations
{
    /// <inheritdoc />
    public partial class ThreatNameVO3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_Value",
                table: "Threats",
                newName: "ThreatName_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_Name_Value",
                table: "Threats",
                newName: "IX_Threats_ThreatName_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThreatName_Value",
                table: "Threats",
                newName: "Name_Value");

            migrationBuilder.RenameIndex(
                name: "IX_Threats_ThreatName_Value",
                table: "Threats",
                newName: "IX_Threats_Name_Value");
        }
    }
}
