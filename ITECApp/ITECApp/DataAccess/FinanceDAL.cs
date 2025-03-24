using MySql.Data.MySqlClient;
using System.Collections.Generic;
using ITECApp.Entities;

namespace ITECApp.DataAccess
{
    public class FinanceDAL
    {
        public List<FinancialTransaction> GetAllTransactions()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                const string query = @"SELECT 
                    t.transaction_id AS TransactionId,
                    t.amount AS Amount,
                    t.from_entity_type AS FromEntityType,
                    t.to_entity_type AS ToEntityType,
                    t.description AS Description,
                    t.date_recorded AS DateRecorded,
                    l.value AS TransactionType
                FROM finances t
                JOIN lookup l ON t.type_id = l.lookup_id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    return DataReaderMap.ToList<FinancialTransaction>(cmd.ExecuteReader());
                }
            }
        }
    }
}