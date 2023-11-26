using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCommentMediaCommentReactionsMessageReactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Messages_MessageID",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_PostID",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "Medias",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_MessageID",
                table: "Medias",
                newName: "IX_Medias_MessageId");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Reactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Reactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_MessageId",
                table: "Reactions",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_CommentId",
                table: "Medias",
                column: "CommentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Comments_CommentId",
                table: "Reactions",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Messages_MessageId",
                table: "Reactions",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_PostID",
                table: "Reactions",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Comments_CommentId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Messages_MessageId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Comments_CommentId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Messages_MessageId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_PostID",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_MessageId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Medias_CommentId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Medias",
                newName: "MessageID");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_MessageId",
                table: "Medias",
                newName: "IX_Medias_MessageID");

            migrationBuilder.AlterColumn<int>(
                name: "PostID",
                table: "Reactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Messages_MessageID",
                table: "Medias",
                column: "MessageID",
                principalTable: "Messages",
                principalColumn: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_PostID",
                table: "Reactions",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
