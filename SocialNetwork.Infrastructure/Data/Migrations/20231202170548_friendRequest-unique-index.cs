using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class friendRequestuniqueindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderProfileID",
                table: "FriendRequests");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderProfileID_ReceiverProfileID",
                table: "FriendRequests",
                columns: new[] { "SenderProfileID", "ReceiverProfileID" },
                unique: true,
                filter: "[SenderProfileID] IS NOT NULL AND [ReceiverProfileID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderProfileID_ReceiverProfileID",
                table: "FriendRequests");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderProfileID",
                table: "FriendRequests",
                column: "SenderProfileID");
        }
    }
}
