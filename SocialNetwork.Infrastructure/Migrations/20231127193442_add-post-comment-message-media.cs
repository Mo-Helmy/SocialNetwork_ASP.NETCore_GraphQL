using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpostcommentmessagemedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Comments_CommentId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Messages_MessageId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Medias",
                newName: "Path");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Medias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_UserId",
                table: "Medias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_AspNetUsers_UserId",
                table: "Medias",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Comments_CommentId",
                table: "Medias",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Messages_MessageId",
                table: "Medias",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_AspNetUsers_UserId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Comments_CommentId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Messages_MessageId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_UserId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Medias",
                newName: "Location");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Comments_CommentId",
                table: "Medias",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Messages_MessageId",
                table: "Medias",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageID");
        }
    }
}
