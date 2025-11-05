
using System;

namespace BankingApp.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public string Valuta { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; } // Annual interest rate as percentage (e.g., 2.5 for 2.5%)
        public DateTime LastInterestCalculation { get; set; } = DateTime.Now;

        // Parameterless constructor for JSON deserialization
        public BankAccount() { }

        public BankAccount(string accountNumber, string accountName, string accountType, string valuta, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            AccountType = accountType;
            Valuta = valuta;
            Balance = initialBalance;
            InterestRate = accountType.ToLower() == "sparkonto" ? 2.5m : 0m; // Default 2.5% for savings accounts
            LastInterestCalculation = DateTime.Now;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }

        public decimal CalculateInterest()
        {
            if (InterestRate <= 0 || Balance <= 0)
                return 0;

            // Calculate days since last interest calculation
            var daysSinceLastCalculation = (DateTime.Now - LastInterestCalculation).Days;
            
            // Daily interest rate (annual rate / 365)
            var dailyRate = InterestRate / 100 / 365;
            
            // Calculate compound daily interest
            var interestAmount = Balance * (decimal)Math.Pow((double)(1 + dailyRate), daysSinceLastCalculation) - Balance;
            
            return Math.Round(interestAmount, 2);
        }

        public void ApplyInterest()
        {
            var interest = CalculateInterest();
            if (interest > 0)
            {
                Balance += interest;
                LastInterestCalculation = DateTime.Now;
            }
        }
    }
}