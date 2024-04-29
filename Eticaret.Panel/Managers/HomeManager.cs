using Dapper;
using Eticaret.Model.ViewModels;
using Microsoft.Data.SqlClient;

namespace Eticaret.Panel.Managers
{
    public static class HomeManager
    {
        public static async Task<Home?> OzetToplam()
        {
            SqlConnection conn = DatabaseConnection.GetConnection;
            string sorgu = @"SELECT 
                            (SELECT COUNT(*) FROM Satis) AS ToplamSatisAdeti,
                            (SELECT SUM(Fiyat * Adet) FROM SatisDetay) AS ToplamSatisTutari,
                            (SELECT Tarih FROM Satis ORDER BY Tarih DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY) AS SonSatisTarihi";
            Home? homeOzet = await conn.QueryFirstOrDefaultAsync<Home>(sorgu);
            return homeOzet;
        }
    }
}
