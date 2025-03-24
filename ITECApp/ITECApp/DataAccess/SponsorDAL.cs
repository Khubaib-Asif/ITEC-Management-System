using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ITECApp.Entities;

namespace ITECApp.DataAccess
{
    public class SponsorDAL
    {
        private readonly string connectionString;

        public SponsorDAL()
        {
            // Initialize the connection string (replace with your actual connection string)
            connectionString = "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";
        }

        public List<Sponsor> GetAllSponsors()
        {
            List<Sponsor> sponsors = new List<Sponsor>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sponsors"; // Adjust the query as needed
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sponsor sponsor = new Sponsor
                            {
                                SponsorId = reader.GetInt32("SponsorId"),
                                SponsorName = reader.GetString("SponsorName"),
                                SponsorType = reader.GetString("SponsorType")
                            };
                            sponsors.Add(sponsor);
                        }
                    }
                }
            }

            return sponsors;
        }

        public void AddSponsor(Sponsor sponsor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Sponsors (SponsorName, SponsorType) VALUES (@SponsorName, @SponsorType)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SponsorName", sponsor.SponsorName);
                    command.Parameters.AddWithValue("@SponsorType", sponsor.SponsorType);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSponsor(Sponsor sponsor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Sponsors SET SponsorName = @SponsorName, SponsorType = @SponsorType WHERE SponsorId = @SponsorId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SponsorId", sponsor.SponsorId);
                    command.Parameters.AddWithValue("@SponsorName", sponsor.SponsorName);
                    command.Parameters.AddWithValue("@SponsorType", sponsor.SponsorType);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSponsor(int sponsorId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Sponsors WHERE SponsorId = @SponsorId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SponsorId", sponsorId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
