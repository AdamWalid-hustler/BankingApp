using System;
using System.Collections.Generic;
using BankingApp.Models;

namespace BankingApp.Services
{
    public interface IAccountService
    {
        void CreateAccount(string name, string accountType, string valuta);
        void Deposit(int accountId, decimal amount);
        void Withdraw(int accountId, decimal amount);
        void TransferFunds(int fromAccount, int toAccount, decimal amount);
        void CreateTransaction(int accountId, decimal amount, string type, string description);
        IEnumerable<Transaction> GetTransactionHistory(int accountId);
        IEnumerable<BankingApp.Models.BankAccount> GetAccounts();
        IEnumerable<Transaction> FilterHistory(int accountId, DateTime? fromDate, DateTime? toDate, string? type);
        IEnumerable<Transaction> SortHistory(int accountId, string sortBy, bool ascending);
        void ApplyInterest(int accountId);
        void ApplyInterestToAllSavingsAccounts();
        string ExportData();
        Task ImportData(string jsonData);
    }
}