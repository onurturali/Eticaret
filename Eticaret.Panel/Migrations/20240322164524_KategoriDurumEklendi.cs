using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticaret.Panel.Migrations
{
    public partial class KategoriDurumEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Durum",
                table: "Kategori",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Kategori");
        }
    }
}
