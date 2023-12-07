using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changefriendShiptofriendRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    FriendRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiverProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FriendRequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.FriendRequestID);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Profiles_ReceiverProfileID",
                        column: x => x.ReceiverProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_FriendRequests_Profiles_SenderProfileID",
                        column: x => x.SenderProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverProfileID",
                table: "FriendRequests",
                column: "ReceiverProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderProfileID",
                table: "FriendRequests",
                column: "SenderProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    FriendshipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FriendshipStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.FriendshipID);
                    table.ForeignKey(
                        name: "FK_Friendships_Profiles_ReceiverProfileID",
                        column: x => x.ReceiverProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_Friendships_Profiles_SenderProfileID",
                        column: x => x.SenderProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ReceiverProfileID",
                table: "Friendships",
                column: "ReceiverProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_SenderProfileID",
                table: "Friendships",
                column: "SenderProfileID");
        }
    }
}
