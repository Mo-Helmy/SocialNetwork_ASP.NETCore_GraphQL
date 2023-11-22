using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_User1ID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_User2ID",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User1ID",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User2ID",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "User1ID",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "User2ID",
                table: "Chats");

            migrationBuilder.CreateTable(
                name: "ChatParticipants",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ChatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatParticipants", x => new { x.UserID, x.ChatID });
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Chats_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chats",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_ChatID",
                table: "ChatParticipants",
                column: "ChatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatParticipants");

            migrationBuilder.AddColumn<int>(
                name: "User1ID",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User2ID",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1ID",
                table: "Chats",
                column: "User1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2ID",
                table: "Chats",
                column: "User2ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_User1ID",
                table: "Chats",
                column: "User1ID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_User2ID",
                table: "Chats",
                column: "User2ID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
