using System;

namespace ITECApp.Entities
{
    public class FinancialTransaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string FromEntityType { get; set; }
        public string ToEntityType { get; set; }
        public string Description { get; set; }
        public DateTime DateRecorded { get; set; }
        public string TransactionType { get; set; }
    }
}