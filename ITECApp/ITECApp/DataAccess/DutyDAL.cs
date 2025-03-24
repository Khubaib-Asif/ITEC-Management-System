using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ITECApp.Entities;

namespace ITECApp.DataAccess
{
    public class DutyDAL
    {
        private readonly string connectionString;

        public DutyDAL()
        {
            // Initialize the connection string (replace with your actual connection string)
            connectionString = "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";
        }

        public List<Duty> GetAllDuties()
        {
            List<Duty> duties = new List<Duty>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Duties"; // Adjust the query as needed
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Duty duty = new Duty
                            {
                                DutyId = reader.GetInt32("DutyId"),
                                TaskDescription = reader.GetString("TaskDescription"),
                                Status = reader.GetString("Status")
                            };
                            duties.Add(duty);
                        }
                    }
                }
            }

            return duties;
        }

        public void AssignDuty(int dutyId, int assigneeId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Duties SET AssigneeId = @AssigneeId WHERE DutyId = @DutyId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DutyId", dutyId);
                    command.Parameters.AddWithValue("@AssigneeId", assigneeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

