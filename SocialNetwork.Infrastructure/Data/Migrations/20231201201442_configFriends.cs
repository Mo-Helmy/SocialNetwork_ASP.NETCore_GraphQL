using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class configFriends : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    FriendID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfileID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.FriendID);
                    table.ForeignKey(
                        name: "FK_Friends_Profiles_FriendProfileID",
                        column: x => x.FriendProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_Friends_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendProfileID_ProfileID",
                table: "Friends",
                columns: new[] { "FriendProfileID", "ProfileID" },
                unique: true,
                filter: "[FriendProfileID] IS NOT NULL AND [ProfileID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ProfileID",
                table: "Friends",
                column: "ProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
