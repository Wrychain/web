using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caspnetti.DAL.Migrations
{
    /// <inheritdoc />
    public partial class added_receiver_to_platform_invite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "PlatformInvite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformInvite_ReceiverId",
                table: "PlatformInvite",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformInvite_User_ReceiverId",
                table: "PlatformInvite",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformInvite_User_ReceiverId",
                table: "PlatformInvite");

            migrationBuilder.DropIndex(
                name: "IX_PlatformInvite_ReceiverId",
                table: "PlatformInvite");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "PlatformInvite");
        }
    }
}
