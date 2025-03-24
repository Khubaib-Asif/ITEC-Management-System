using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ITECApp.Entities;

namespace ITECApp.DataAccess
{
    public class VendorDAL
    {
        private readonly string connectionString;

        public VendorDAL()
        {
            // Initialize the connection string (replace with your actual connection string)
            connectionString = "Server=127.0.0.1;Database=projecta;Uid=root;Pwd=1234567890-=!@#$%^&*()_+;";
        }

        public List<Vendor> GetAllVendors()
        {
            List<Vendor> vendors = new List<Vendor>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vendors"; // Adjust the query as needed
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vendor vendor = new Vendor
                            {
                                VendorId = reader.GetInt32("VendorId"),
                                VendorName = reader.GetString("VendorName"),
                                VendorType = reader.GetString("VendorType")
                            };
                            vendors.Add(vendor);
                        }
                    }
                }
            }

            return vendors;
        }

        public void AddVendor(Vendor vendor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Vendors (VendorName, VendorType) VALUES (@VendorName, @VendorType)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                    command.Parameters.AddWithValue("@VendorType", vendor.VendorType);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVendor(Vendor vendor)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Vendors SET VendorName = @VendorName, VendorType = @VendorType WHERE VendorId = @VendorId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VendorId", vendor.VendorId);
                    command.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                    command.Parameters.AddWithValue("@VendorType", vendor.VendorType);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteVendor(int vendorId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Vendors WHERE VendorId = @VendorId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VendorId", vendorId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

