using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class messagebox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverId1",
                table: "MessageBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderId1",
                table: "MessageBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MessageBoxes_ReciverId1",
                table: "MessageBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MessageBoxes_SenderId1",
                table: "MessageBoxes");

            migrationBuilder.DropColumn(
                name: "ReciverId1",
                table: "MessageBoxes");

            migrationBuilder.DropColumn(
                name: "SenderId1",
                table: "MessageBoxes");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "MessageBoxes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ReciverId",
                table: "MessageBoxes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoxes_ReciverId",
                table: "MessageBoxes",
                column: "ReciverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoxes_SenderId",
                table: "MessageBoxes",
                column: "SenderId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverId",
                table: "MessageBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderId",
                table: "MessageBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MessageBoxes_ReciverId",
                table: "MessageBoxes");

            migrationBuilder.DropIndex(
                name: "IX_MessageBoxes_SenderId",
                table: "MessageBoxes");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "MessageBoxes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReciverId",
                table: "MessageBoxes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReciverId1",
                table: "MessageBoxes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId1",
                table: "MessageBoxes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoxes_ReciverId1",
                table: "MessageBoxes",
                column: "ReciverId1");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoxes_SenderId1",
                table: "MessageBoxes",
                column: "SenderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_ReciverId1",
                table: "MessageBoxes",
                column: "ReciverId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageBoxes_AspNetUsers_SenderId1",
                table: "MessageBoxes",
                column: "SenderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
