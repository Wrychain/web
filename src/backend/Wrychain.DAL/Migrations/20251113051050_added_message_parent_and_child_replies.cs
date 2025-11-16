using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrychain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class added_message_parent_and_child_replies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageMessage",
                columns: table => new
                {
                    ChildRepliesId = table.Column<int>(type: "int", nullable: false),
                    ParentRepliesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageMessage", x => new { x.ChildRepliesId, x.ParentRepliesId });
                    table.ForeignKey(
                        name: "FK_MessageMessage_Message_ChildRepliesId",
                        column: x => x.ChildRepliesId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageMessage_Message_ParentRepliesId",
                        column: x => x.ParentRepliesId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageMessage_ParentRepliesId",
                table: "MessageMessage",
                column: "ParentRepliesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageMessage");
        }
    }
}
