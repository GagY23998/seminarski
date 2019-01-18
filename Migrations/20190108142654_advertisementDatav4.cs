using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class advertisementDatav4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId1",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_AppUserId1",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Advertisements");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Advertisements",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Advertisements",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AppUserId1",
                table: "Advertisements",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_AppUserId1",
                table: "Advertisements",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
