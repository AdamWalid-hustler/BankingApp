
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly List<BankAccount> _accounts = new();
        private readonly List<Transaction> _transactions = new();
        private readonly IStorageService _storageService;
        private const string AccountsKey = "banking_accounts";
        private const string TransactionsKey = "banking_transactions";

        public AccountService(IStorageService storageService)
        {
            _storageService = storageService;
            _ = LoadDataAsync(); // Fire and forget initialization
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var accounts = await _storageService.GetDataAsync<List<BankAccount>>(AccountsKey);
                if (accounts != null)
                {
                    _accounts.Clear();
                    _accounts.AddRange(accounts);
                }

                var transactions = await _storageService.GetDataAsync<List<Transaction>>(TransactionsKey);
                if (transactions != null)
                {
                    _transactions.Clear();
                    _transactions.AddRange(transactions);
                }
            }
            catch
            {
                // If loading fails, start with empty lists
            }
        }

        private async Task SaveDataAsync()
        {
            try
            {
                await _storageService.SaveDataAsync(AccountsKey, _accounts);
                await _storageService.SaveDataAsync(TransactionsKey, _transactions);
            }
            catch
            {
                // Silently fail if save doesn't work
            }
        }

        public void CreateAccount(string name, string accountType, string valuta)
        {
            var accountNumber = Guid.NewGuid().ToString().Substring(0, 8);
            var newAccount = new BankAccount(accountNumber, name, accountType, valuta);
            _accounts.Add(newAccount);
            _ = SaveDataAsync(); // Save after mutation
        }

        public void Deposit(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new Exception("Account not found.");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

            account.Deposit(amount);
            AddTransaction(accountId, amount, "Deposit", "Deposit made.");
            _ = SaveDataAsync(); // Save after mutation
        }

        public void Withdraw(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new Exception("Account not found.");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            if (account.Balance < amount) throw new InvalidOperationException("Insufficient funds.");

            account.Withdraw(amount);
            AddTransaction(accountId, amount, "Withdraw", "Withdrawal made.");
            _ = SaveDataAsync(); // Save after mutation
        }

        public void TransferFunds(int fromAccountId, int toAccountId, decimal amount)
        {
            if (fromAccountId == toAccountId)
                throw new InvalidOperationException("Cannot transfer to the same account.");

            Withdraw(fromAccountId, amount);
            Deposit(toAccountId, amount);
            AddTransaction(fromAccountId, amount, "Transfer Out", $"Transferred to account {toAccountId}");
            AddTransaction(toAccountId, amount, "Transfer In", $"Received from account {fromAccountId}");
            // Note: Withdraw and Deposit already call SaveDataAsync, so data is persisted
        }

        public void CreateTransaction(int accountId, decimal amount, string type, string description)
        {
            AddTransaction(accountId, amount, type, description);
            _ = SaveDataAsync(); // Save after mutation
        }

        public IEnumerable<Transaction> GetTransactionHistory(int accountId)
        {
            return _transactions.Where(t => t.AccountId == accountId);
        }

        public IEnumerable<BankAccount> GetAccounts()
        {
            // Return a shallow copy to prevent external mutation of internal list
            return _accounts.ToList();
        }

        public void ApplyInterest(int accountId)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new Exception("Account not found.");
            
            if (account.AccountType.ToLower() != "sparkonto")
                throw new InvalidOperationException("Interest can only be applied to Sparkonto (savings) accounts.");

            var interestAmount = account.CalculateInterest();
            if (interestAmount > 0)
            {
                account.ApplyInterest();
                AddTransaction(accountId, interestAmount, "Interest", $"Interest applied at {account.InterestRate}% annual rate");
                _ = SaveDataAsync(); // Save after mutation
            }
        }

        public void ApplyInterestToAllSavingsAccounts()
        {
            var savingsAccounts = _accounts.Where(a => a.AccountType.ToLower() == "sparkonto").ToList();
            
            foreach (var account in savingsAccounts)
            {
                var accountIndex = _accounts.IndexOf(account);
                if (accountIndex >= 0)
                {
                    ApplyInterest(accountIndex);
                }
            }
        }

        public IEnumerable<Transaction> FilterHistory(int accountId, DateTime? fromDate, DateTime? toDate, string? type)
        {
            var query = _transactions.Where(t => t.AccountId == accountId);

            if (fromDate.HasValue) query = query.Where(t => t.Date >= fromDate.Value);
            if (toDate.HasValue) query = query.Where(t => t.Date <= toDate.Value);
            if (!string.IsNullOrEmpty(type)) query = query.Where(t => t.Type == type);

            return query;
        }

        public IEnumerable<Transaction> SortHistory(int accountId, string sortBy, bool ascending)
        {
            var query = _transactions.Where(t => t.AccountId == accountId);

            return sortBy.ToLower() switch
            {
                "amount" => ascending ? query.OrderBy(t => t.Amount) : query.OrderByDescending(t => t.Amount),
                "date" => ascending ? query.OrderBy(t => t.Date) : query.OrderByDescending(t => t.Date),
                _ => query
            };
        }

        // Helper methods
        private BankAccount? GetAccountById(int accountId)
        {
            // Simulated ID = index position
            if (accountId < 0 || accountId >= _accounts.Count)
                return null;

            return _accounts[accountId];
        }

        private void AddTransaction(int accountId, decimal amount, string type, string description)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new Exception("Account not found.");

            var transaction = new Transaction(
                accountId,
                type,
                amount,
                account.Balance,
                description
            );
            _transactions.Add(transaction);
        }
    }
}
