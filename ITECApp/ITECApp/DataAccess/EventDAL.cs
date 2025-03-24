using ITECApp.Entities;
using ITECApp.Utilities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace ITECApp.DataAccess
{
    public class EventDAL
    {
        public List<Event> GetAllEvents()
        {
            var events = new List<Event>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Events"; // Adjust the query as needed

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Event
                            {
                                EventId = reader.GetInt32("EventId"),
                                EventName = reader.GetString("EventName"),
                                EventDate = reader.GetDateTime("EventDate")
                            });
                        }
                    }
                }
            }
            return events;
        }

        public Response<EventResult> GetEventResultById(int resultId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT result_id, event_id, participant_id, team_id, position, score, remarks 
                                     FROM event_results WHERE result_id = @resultId LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@resultId", resultId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Response<EventResult>
                                {
                                    IsSuccess = true,
                                    Data = new EventResult
                                    {
                                        ResultId = reader.GetInt32("result_id"),
                                        EventId = reader.IsDBNull("event_id") ? (int?)null : reader.GetInt32("event_id"),
                                        ParticipantId = reader.IsDBNull("participant_id") ? (int?)null : reader.GetInt32("participant_id"),
                                        TeamId = reader.IsDBNull("team_id") ? (int?)null : reader.GetInt32("team_id"),
                                        Position = reader.IsDBNull("position") ? (int?)null : reader.GetInt32("position"),
                                        Score = reader.IsDBNull("score") ? (decimal?)null : reader.GetDecimal("score"),
                                        Remarks = reader.IsDBNull("remarks") ? null : reader.GetString("remarks")
                                    }
                                };
                            }
                            return new Response<EventResult> { IsSuccess = false, Message = "Event result not found" };
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    return new Response<EventResult> { IsSuccess = false, Message = $"Database Error: {ex.Message}" };
                }
            }
        }

        public List<EventResult> GetAllEventResults()
        {
            var eventResults = new List<EventResult>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT result_id, event_id, participant_id, team_id, position, score, remarks FROM event_results";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventResults.Add(new EventResult
                        {
                            ResultId = reader.GetInt32("result_id"),
                            EventId = reader.IsDBNull("event_id") ? (int?)null : reader.GetInt32("event_id"),
                            ParticipantId = reader.IsDBNull("participant_id") ? (int?)null : reader.GetInt32("participant_id"),
                            TeamId = reader.IsDBNull("team_id") ? (int?)null : reader.GetInt32("team_id"),
                            Position = reader.IsDBNull("position") ? (int?)null : reader.GetInt32("position"),
                            Score = reader.IsDBNull("score") ? (decimal?)null : reader.GetDecimal("score"),
                            Remarks = reader.IsDBNull("remarks") ? null : reader.GetString("remarks")
                        });
                    }
                }
            }
            return eventResults;
        }

        public List<Event> GetRegisteredEvents(int studentId)
        {
            var events = new List<Event>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT e.event_id, e.event_name, e.event_date
                                 FROM itec_events e
                                 JOIN event_participants ep ON e.event_id = ep.event_id
                                 WHERE ep.participant_id = @studentId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Event
                            {
                                EventId = reader.GetInt32("event_id"),
                                EventName = reader.GetString("event_name"),
                                EventDate = reader.GetDateTime("event_date")
                            });
                        }
                    }
                }
            }
            return events;
        }

        public List<EventResult> GetEventResults(int studentId)
        {
            var eventResults = new List<EventResult>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"SELECT result_id, event_id, participant_id, team_id, position, score, remarks 
                                 FROM event_results WHERE participant_id = @studentId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventResults.Add(new EventResult
                            {
                                ResultId = reader.GetInt32("result_id"),
                                EventId = reader.IsDBNull("event_id") ? (int?)null : reader.GetInt32("event_id"),
                                ParticipantId = reader.IsDBNull("participant_id") ? (int?)null : reader.GetInt32("participant_id"),
                                TeamId = reader.IsDBNull("team_id") ? (int?)null : reader.GetInt32("team_id"),
                                Position = reader.IsDBNull("position") ? (int?)null : reader.GetInt32("position"),
                                Score = reader.IsDBNull("score") ? (decimal?)null : reader.GetDecimal("score"),
                                Remarks = reader.IsDBNull("remarks") ? null : reader.GetString("remarks")
                            });
                        }
                    }
                }
            }
            return eventResults;
        }
    }
}

public static class DatabaseHelper
{
    public static MySqlConnection GetConnection()
    {
        string connectionString = "your_connection_string_here";
        return new MySqlConnection(connectionString);
    }
}

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
}

public class EventResult
{
    public int ResultId { get; set; }
    public int? EventId { get; set; }
    public int? ParticipantId { get; set; }
    public int? TeamId { get; set; }
    public int? Position { get; set; }
    public decimal? Score { get; set; }
    public string? Remarks { get; set; }
}

public class Event
{
    public int EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
}


