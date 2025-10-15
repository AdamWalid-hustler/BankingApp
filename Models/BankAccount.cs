
namespace BankingApp.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string Valuta { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, string accountName, string accountType, string valuta, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            AccountType = accountType;
            Valuta = valuta;
            Balance = initialBalance;
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
    }
}