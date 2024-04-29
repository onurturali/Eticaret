using Microsoft.Data.SqlClient;

namespace Eticaret.Panel.Managers
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection
        {
            get
            {
                SqlConnection conn = new("Server=DESKTOP-UQD4ET0; Database=BiMilyoncu; TrustServerCertificate=True; Trusted_Connection=True;");
                conn.Open();
                return conn;
            }
        }
    }
}
