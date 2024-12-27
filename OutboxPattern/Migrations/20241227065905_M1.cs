using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutboxPattern.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OutboxMessages",
                newName: "PayloadType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayloadType",
                table: "OutboxMessages",
                newName: "Type");
        }
    }
}
