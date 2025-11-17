using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrychain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ip_and_user_agent_to_login_attempt_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "LoginAttempt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "LoginAttempt",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "LoginAttempt");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "LoginAttempt");
        }
    }
}
