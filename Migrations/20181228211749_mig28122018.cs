using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class mig28122018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics");

            migrationBuilder.AlterColumn<int>(
                name: "KategorijaID",
                table: "CategoryCharachteristics",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics",
                column: "KategorijaID",
                principalTable: "Kategorije",
                principalColumn: "KategorijaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics");

            migrationBuilder.AlterColumn<int>(
                name: "KategorijaID",
                table: "CategoryCharachteristics",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics",
                column: "KategorijaID",
                principalTable: "Kategorije",
                principalColumn: "KategorijaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
