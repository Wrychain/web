using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrychain.DAL.Migrations
{
    /// <inheritdoc />
    public partial class added_station_to_channel_reader_and_writer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelReader_User_UserId",
                table: "ChannelReader");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelWriter_User_UserId",
                table: "ChannelWriter");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChannelWriter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "ChannelWriter",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChannelReader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "ChannelReader",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChannelWriter_StationId",
                table: "ChannelWriter",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelReader_StationId",
                table: "ChannelReader",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelReader_Station_StationId",
                table: "ChannelReader",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelReader_User_UserId",
                table: "ChannelReader",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelWriter_Station_StationId",
                table: "ChannelWriter",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelWriter_User_UserId",
                table: "ChannelWriter",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelReader_Station_StationId",
                table: "ChannelReader");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelReader_User_UserId",
                table: "ChannelReader");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelWriter_Station_StationId",
                table: "ChannelWriter");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelWriter_User_UserId",
                table: "ChannelWriter");

            migrationBuilder.DropIndex(
                name: "IX_ChannelWriter_StationId",
                table: "ChannelWriter");

            migrationBuilder.DropIndex(
                name: "IX_ChannelReader_StationId",
                table: "ChannelReader");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "ChannelWriter");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "ChannelReader");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChannelWriter",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChannelReader",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelReader_User_UserId",
                table: "ChannelReader",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelWriter_User_UserId",
                table: "ChannelWriter",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
