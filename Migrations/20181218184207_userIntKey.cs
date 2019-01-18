using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class userIntKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverId",
                table: "MessageBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderId",
                table: "MessageBoxes");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "MessageBoxes",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "ReciverId",
                table: "MessageBoxes",
                newName: "ReciverID");

            migrationBuilder.RenameIndex(
                name: "IX_MessageBoxes_SenderId",
                table: "MessageBoxes",
                newName: "IX_MessageBoxes_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_MessageBoxes_ReciverId",
                table: "MessageBoxes",
                newName: "IX_MessageBoxes_ReciverID");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverID",
                table: "MessageBoxes",
                column: "ReciverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderID",
                table: "MessageBoxes",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverID",
                table: "MessageBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderID",
                table: "MessageBoxes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "MessageBoxes",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "ReciverID",
                table: "MessageBoxes",
                newName: "ReciverId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageBoxes_SenderID",
                table: "MessageBoxes",
                newName: "IX_MessageBoxes_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageBoxes_ReciverID",
                table: "MessageBoxes",
                newName: "IX_MessageBoxes_ReciverId");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverId",
                table: "MessageBoxes",
                column: "ReciverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderId",
                table: "MessageBoxes",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
