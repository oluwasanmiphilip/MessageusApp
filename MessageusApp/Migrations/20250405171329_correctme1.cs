using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageusApp.Migrations
{
    /// <inheritdoc />
    public partial class correctme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentAT",
                table: "Messages",
                newName: "SentAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "SentAT");
        }
    }
}
