using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class chatmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_UserID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Posts_PostID",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserID",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Chats");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MessageID",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MessageID",
                table: "Medias",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Messages_MessageID",
                table: "Medias",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Posts_PostID",
                table: "Medias",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Messages_MessageID",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Posts_PostID",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_MessageID",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MessageID",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Chats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserID",
                table: "Chats",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_UserID",
                table: "Chats",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Posts_PostID",
                table: "Medias",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
