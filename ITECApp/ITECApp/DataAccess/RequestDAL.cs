using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ITECApp.Entities;

namespace ITECApp.DataAccess
{
    public class RequestDAL
    {
        private readonly string connectionString;

        public RequestDAL()
        {
            // Initialize the connection string (replace with your actual connection string)
            connectionString = "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";
        }

        public List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Requests"; // Adjust the query as needed
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Request request = new Request
                            {
                                RequestId = reader.GetInt32("RequestId"),
                                RequestType = reader.GetString("RequestType"),
                                RequestStatus = reader.GetString("RequestStatus")
                            };
                            requests.Add(request);
                        }
                    }
                }
            }

            return requests;
        }

        public void ApproveRequest(int requestId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Requests SET RequestStatus = 'Approved' WHERE RequestId = @RequestId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RequestId", requestId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RejectRequest(int requestId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Requests SET RequestStatus = 'Rejected' WHERE RequestId = @RequestId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RequestId", requestId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
