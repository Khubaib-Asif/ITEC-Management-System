using ITECApp.Entities;
using ITECApp.Utilities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ITECApp.DataAccess
{
    public class RoleDAL
    {
        public Role GetRoleById(int roleId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT lookup_id, value 
                                 FROM lookup 
                                 WHERE lookup_id = @roleId AND category = 'UserRoles'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Role
                            {
                                RoleId = reader.GetInt32("lookup_id"),
                                RoleName = reader.GetString("value")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Role> GetAllRoles()
        {
            var roles = new List<Role>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT lookup_id, value 
                                 FROM lookup 
                                 WHERE category = 'UserRoles'";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            RoleId = reader.GetInt32("lookup_id"),
                            RoleName = reader.GetString("value")
                        });
                    }
                }
            }
            return roles;
        }
    }
}
