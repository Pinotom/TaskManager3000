using System.Configuration;

namespace DAL
{
    class DBConnection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }
    }
}
