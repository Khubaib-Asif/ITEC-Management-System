using System.Data;
using MySql.Data.MySqlClient;

namespace ITECApp.DataAccess
{
    public class ReportDAL
    {
        private readonly string connectionString;

        public ReportDAL()
        {
            // Initialize the connection string (replace with your actual connection string)
            connectionString = "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";
        }

        public DataTable GenerateReport(string reportType)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reports WHERE ReportType = @ReportType"; // Adjust the query as needed
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReportType", reportType);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}

