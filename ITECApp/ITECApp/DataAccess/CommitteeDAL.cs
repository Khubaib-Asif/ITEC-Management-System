using ITECApp.Entities;
using ITECApp.Utilities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ITECApp.DataAccess
{
    public class CommitteeDAL
    {
        public List<Committee> GetAllCommittees()
        {
            var committees = new List<Committee>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Committees"; // Adjust the query as needed

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            committees.Add(new Committee
                            {
                                CommitteeId = reader.GetInt32("CommitteeId"),
                                CommitteeName = reader.GetString("CommitteeName")
                            });
                        }
                    }
                }
            }
            return committees;
        }

        public List<Committee> GetCommitteesByFaculty(int facultyId)
        {
            var committees = new List<Committee>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT c.committee_id, c.committee_name 
                                 FROM committees c
                                 JOIN committee_members cm ON c.committee_id = cm.committee_id
                                 WHERE cm.member_id = @facultyId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@facultyId", facultyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            committees.Add(new Committee
                            {
                                CommitteeId = reader.GetInt32("committee_id"),
                                CommitteeName = reader.GetString("committee_name")
                            });
                        }
                    }
                }
            }
            return committees;
        }

        public List<Duty> GetDutiesByFaculty(int facultyId)
        {
            var duties = new List<Duty>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT d.duty_id, d.task_description, l.value AS status 
                                 FROM duties d
                                 JOIN committee_members cm ON d.committee_id = cm.committee_id
                                 JOIN lookup l ON d.status_id = l.lookup_id
                                 WHERE cm.member_id = @facultyId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@facultyId", facultyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            duties.Add(new Duty
                            {
                                DutyId = reader.GetInt32("duty_id"),
                                TaskDescription = reader.GetString("task_description"),
                                Status = reader.GetString("status")
                            });
                        }
                    }
                }
            }
            return duties;
        }
    }
}


