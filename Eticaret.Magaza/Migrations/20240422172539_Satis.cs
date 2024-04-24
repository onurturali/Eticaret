using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticaret.Magaza.Migrations
{
    public partial class Satis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Satis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier rowguidcol", nullable: false, defaultValueSql: "newid()"),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SatisDetay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier rowguidcol", nullable: false, defaultValueSql: "newid()"),
                    SatisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrunId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisDetay", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satis");

            migrationBuilder.DropTable(
                name: "SatisDetay");
        }
    }
}
