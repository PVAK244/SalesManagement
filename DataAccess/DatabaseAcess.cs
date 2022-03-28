using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace DataAccess
{
    public class DatabaseAcess
    {
        protected SqlConnection conn;
        protected void OpenConnection()
        {
            if (conn == null)
            {
                conn = new(GetConnectionString());
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        protected void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            return config["ConnectionStrings:FStoreDB"];
        }
    }
}
