using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutboxPattern.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSuccess",
                table: "OutboxMessages",
                newName: "IsSuccessful");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSuccessful",
                table: "OutboxMessages",
                newName: "IsSuccess");
        }
    }
}
