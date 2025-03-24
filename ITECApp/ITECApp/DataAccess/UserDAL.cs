using ITECApp.Entities;
using ITECApp.Utilities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ITECApp.DataAccess
{
    public class UserDAL
    {
        public Response<User> GetUserByCredential(string credential)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT user_id, username, email, password_hash, role_id 
                                       FROM users WHERE username = @cred OR email = @cred LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cred", credential);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Response<User>
                                {
                                    IsSuccess = true,
                                    Data = new User
                                    {
                                        UserId = reader.GetInt32("user_id"),
                                        Username = reader.GetString("username"),
                                        Email = reader.GetString("email"),
                                        PasswordHash = reader.GetString("password_hash"),
                                        RoleId = reader.GetInt32("role_id")
                                    }
                                };
                            }
                            return new Response<User> { IsSuccess = false, Message = "User not found" };
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    return new Response<User> { IsSuccess = false, Message = $"Database Error: {ex.Message}" };
                }
            }
        }

        public Response<User> CreateUser(User user)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO users 
                                       (username, email, password_hash, role_id)
                                       VALUES (@uname, @email, @pwd, @roleId)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", user.Username);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@pwd", user.PasswordHash);
                        cmd.Parameters.AddWithValue("@roleId", user.RoleId);

                        int rows = cmd.ExecuteNonQuery();
                        return new Response<User>
                        {
                            IsSuccess = rows > 0,
                            Message = rows > 0 ? "User created" : "Registration failed"
                        };
                    }
                }
                catch (MySqlException ex)
                {
                    return new Response<User> { IsSuccess = false, Message = $"Database Error: {ex.Message}" };
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, username, email, role_id FROM users";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = reader.GetInt32("user_id"),
                            Username = reader.GetString("username"),
                            Email = reader.GetString("email"),
                            RoleId = reader.GetInt32("role_id")
                        });
                    }
                }
            }
            return users;
        }
    }
}

