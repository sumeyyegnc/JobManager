using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobmanager.Data.Migrations
{
    /// <inheritdoc />
    public partial class lastmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Sirketler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sirketler_KullaniciId",
                table: "Sirketler",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sirketler_Kullanicilar_KullaniciId",
                table: "Sirketler",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sirketler_Kullanicilar_KullaniciId",
                table: "Sirketler");

            migrationBuilder.DropIndex(
                name: "IX_Sirketler_KullaniciId",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Sirketler");
        }
    }
}
