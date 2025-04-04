using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageusApp.Migrations
{
    /// <inheritdoc />
    public partial class now6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentAT",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.RenameColumn(
                name: "SchdeduledTime",
                table: "Messages",
                newName: "ScheduledTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "SentAT");

            migrationBuilder.RenameColumn(
                name: "ScheduledTime",
                table: "Messages",
                newName: "SchdeduledTime");
        }
    }
}
