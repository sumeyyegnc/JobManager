using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobmanager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    SirketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.SirketId);
                });

            migrationBuilder.CreateTable(
                name: "IsIlanlari",
                columns: table => new
                {
                    IsIlaniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayimlanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonBasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsIlanlari", x => x.IsIlaniId);
                    table.ForeignKey(
                        name: "FK_IsIlanlari_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsIlanlari_SirketId",
                table: "IsIlanlari",
                column: "SirketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsIlanlari");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
