
using System;

namespace BankingApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Type { get; set; } = string.Empty; // Insättning, uttag, överföring
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public string Description { get; set; } = string.Empty;

        public Transaction() { }
        public Transaction(int accountId, string type, decimal amount, decimal balanceAfter, string description)
        {
            AccountId = accountId;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
            Description = description;
        }
    }
}