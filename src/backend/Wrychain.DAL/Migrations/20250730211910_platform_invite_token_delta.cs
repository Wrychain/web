using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrychain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class platform_invite_token_delta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "PlatformInvite",
                newName: "TokenHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenHash",
                table: "PlatformInvite",
                newName: "Token");
        }
    }
}
