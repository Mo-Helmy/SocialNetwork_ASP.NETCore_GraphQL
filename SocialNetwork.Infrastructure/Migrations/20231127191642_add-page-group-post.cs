using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpagegrouppost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_GroupID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pages_PageID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RelatedGroupID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RelatedPageID",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_GroupID",
                table: "Posts",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pages_PageID",
                table: "Posts",
                column: "PageID",
                principalTable: "Pages",
                principalColumn: "PageID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_GroupID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pages_PageID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "RelatedGroupID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedPageID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_GroupID",
                table: "Posts",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pages_PageID",
                table: "Posts",
                column: "PageID",
                principalTable: "Pages",
                principalColumn: "PageID");
        }
    }
}
