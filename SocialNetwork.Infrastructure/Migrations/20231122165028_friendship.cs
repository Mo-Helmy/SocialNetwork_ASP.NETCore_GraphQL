using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class friendship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_UserID",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_UserID",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Friendships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Friendships",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserID",
                table: "Friendships",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_UserID",
                table: "Friendships",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
