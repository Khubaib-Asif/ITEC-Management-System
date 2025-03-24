using MySql.Data.MySqlClient;

namespace ITECApp.DataAccess
{
    public static class DatabaseHelper
    {
        private const string ConnectionString =
            "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";

        public static MySqlConnection GetConnection() => new MySqlConnection(ConnectionString);
    }
}