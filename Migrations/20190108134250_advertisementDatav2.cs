using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class advertisementDatav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementTypes_AspNetUsers_AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementTypes_AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AppUserId",
                table: "Advertisements",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AppUserId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Advertisements");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AdvertisementTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementTypes_AppUserId",
                table: "AdvertisementTypes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementTypes_AspNetUsers_AppUserId",
                table: "AdvertisementTypes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
