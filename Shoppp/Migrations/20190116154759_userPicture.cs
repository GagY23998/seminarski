using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class userPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favorites_OmiljeniFavoritesId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OmiljeniFavoritesId",
                table: "AspNetUsers",
                newName: "FavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_OmiljeniFavoritesId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favorites_FavoritesId",
                table: "AspNetUsers",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favorites_FavoritesId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FavoritesId",
                table: "AspNetUsers",
                newName: "OmiljeniFavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_FavoritesId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_OmiljeniFavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favorites_OmiljeniFavoritesId",
                table: "AspNetUsers",
                column: "OmiljeniFavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
