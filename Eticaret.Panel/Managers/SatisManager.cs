using Dapper;
using Eticaret.Model;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Eticaret.Panel.Managers
{
    public static class SatisManager
    {
        public static async Task<List<Satis>> TumunuGetir()
        {
            SqlConnection conn = DatabaseConnection.GetConnection;
            string query = @"SELECT
                            t.*,
                            (SELECT SUM(s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) AS ToplamAdet,
                            (SELECT SUM(s.Fiyat * s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) AS ToplamTutar
                            FROM Satis AS t
                            ORDER BY FaturaNo ASC
                            ";
            IEnumerable<Satis> satislar = await conn.QueryAsync<Satis>(query);
            return satislar.ToList();
        }

        public static async Task<List<Satis>> Filtrele(string faturaNo, DateTime baslangicTarihi, DateTime bitisTarihi, string tutar)
        {
            SqlConnection conn = DatabaseConnection.GetConnection;
            DynamicParameters param = new();
            string query = @"SELECT
                            t.*,
                            (SELECT SUM(s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) AS ToplamAdet,
                            (SELECT SUM(s.Fiyat * s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) AS ToplamTutar
                            FROM Satis AS t
                            WHERE 1 = 1 ";

            if (baslangicTarihi.Year != 1 && bitisTarihi.Year != 1)
            {
                param.Add("@BaslangicTarihi", baslangicTarihi);
                param.Add("@BitisTarihi", bitisTarihi);
                query += " AND t.Tarih > @BaslangicTarihi AND t.Tarih < @BitisTarihi";
            }
            else if (baslangicTarihi.Year != 1 && bitisTarihi.Year == 1)
            {
                param.Add("@BaslangicTarihi", baslangicTarihi);
                query += " AND t.Tarih > @BaslangicTarihi";
            }
            else if (baslangicTarihi.Year == 1 && bitisTarihi.Year != 1)
            {
                param.Add("@BitisTarihi", bitisTarihi);
                query += " AND t.Tarih < @BitisTarihi";
            }

            if (tutar != null && tutar.Split(" ").Length == 2)
            {
                double baslangicTutar = double.Parse(tutar.Split(" ")[0]);
                double bitisTutar = double.Parse(tutar.Split(" ")[1]);
                param.Add("@BaslangicTutar", baslangicTutar);
                param.Add("@BitisTutar", bitisTutar);
                query += @" AND (SELECT SUM(s.Fiyat * s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) > @BaslangicTutar
                            AND (SELECT SUM(s.Fiyat * s.Adet) FROM SatisDetay AS s WHERE s.SatisId = t.Id) < @BitisTutar";
            }

            query += " ORDER BY FaturaNo ASC";
            IEnumerable<Satis> satislar = await conn.QueryAsync<Satis>(query, param);
            return satislar.ToList();
        }
    }
}
