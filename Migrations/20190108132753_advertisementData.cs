using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class advertisementData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikli_Korpe_CartId",
                table: "Artikli");

            migrationBuilder.DropForeignKey(
                name: "FK_Artikli_Favorites_FavoritesId",
                table: "Artikli");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Korpe_KorpaCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyingHistory_Artikli_ArtiklID",
                table: "BuyingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglasi_OglasiType_AdTypeId",
                table: "Oglasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OglasiType",
                table: "OglasiType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Oglasi",
                table: "Oglasi");

            migrationBuilder.DropIndex(
                name: "IX_Oglasi_AdTypeId",
                table: "Oglasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korpe",
                table: "Korpe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategorije",
                table: "Kategorije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artikli",
                table: "Artikli");

            migrationBuilder.DropColumn(
                name: "AdTypeId",
                table: "Oglasi");

            migrationBuilder.RenameTable(
                name: "OglasiType",
                newName: "AdvertisementTypes");

            migrationBuilder.RenameTable(
                name: "Oglasi",
                newName: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Korpe",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "Kategorije",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Artikli",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Artikli_FavoritesId",
                table: "Articles",
                newName: "IX_Articles_FavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_Artikli_CartId",
                table: "Articles",
                newName: "IX_Articles_CartId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AdvertisementTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementTypes",
                table: "AdvertisementTypes",
                column: "AdTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "AdvertisementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "KategorijaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "ArtiklID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Carts_CartId",
                table: "Articles",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Favorites_FavoritesId",
                table: "Articles",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_KorpaCartId",
                table: "AspNetUsers",
                column: "KorpaCartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyingHistory_Articles_ArtiklID",
                table: "BuyingHistory",
                column: "ArtiklID",
                principalTable: "Articles",
                principalColumn: "ArtiklID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCharachteristics_Categories_KategorijaID",
                table: "CategoryCharachteristics",
                column: "KategorijaID",
                principalTable: "Categories",
                principalColumn: "KategorijaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementTypes_AspNetUsers_AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Carts_CartId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Favorites_FavoritesId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_KorpaCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyingHistory_Articles_ArtiklID",
                table: "BuyingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCharachteristics_Categories_KategorijaID",
                table: "CategoryCharachteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementTypes",
                table: "AdvertisementTypes");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementTypes_AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AdvertisementTypes");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Kategorije");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Korpe");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Artikli");

            migrationBuilder.RenameTable(
                name: "AdvertisementTypes",
                newName: "OglasiType");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Oglasi");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_FavoritesId",
                table: "Artikli",
                newName: "IX_Artikli_FavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CartId",
                table: "Artikli",
                newName: "IX_Artikli_CartId");

            migrationBuilder.AddColumn<int>(
                name: "AdTypeId",
                table: "Oglasi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategorije",
                table: "Kategorije",
                column: "KategorijaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korpe",
                table: "Korpe",
                column: "CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artikli",
                table: "Artikli",
                column: "ArtiklID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OglasiType",
                table: "OglasiType",
                column: "AdTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Oglasi",
                table: "Oglasi",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_AdTypeId",
                table: "Oglasi",
                column: "AdTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikli_Korpe_CartId",
                table: "Artikli",
                column: "CartId",
                principalTable: "Korpe",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artikli_Favorites_FavoritesId",
                table: "Artikli",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "FavoritesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Korpe_KorpaCartId",
                table: "AspNetUsers",
                column: "KorpaCartId",
                principalTable: "Korpe",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyingHistory_Artikli_ArtiklID",
                table: "BuyingHistory",
                column: "ArtiklID",
                principalTable: "Artikli",
                principalColumn: "ArtiklID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCharachteristics_Kategorije_KategorijaID",
                table: "CategoryCharachteristics",
                column: "KategorijaID",
                principalTable: "Kategorije",
                principalColumn: "KategorijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oglasi_OglasiType_AdTypeId",
                table: "Oglasi",
                column: "AdTypeId",
                principalTable: "OglasiType",
                principalColumn: "AdTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
