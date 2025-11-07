using System;
using System.Collections.Generic;

namespace Lab1_Task.ConsoleApp
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; private set; }
        public string Currency { get; set; }
        public bool IsActive { get; private set; }
        public string AccountType { get; set; }
        public string CardColor { get; set; }
        public List<Transaction> Transactions { get; private set; } = new();

        public BankAccount(string accountNumber, string ownerName,
            decimal initialBalance, string currency, string accountType, string cardColor)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = initialBalance >= 0 ? initialBalance : 0m;
            Currency = currency;
            AccountType = accountType;
            CardColor = cardColor;
            IsActive = true;
        }

        public void Deposit(decimal amount)
        {
            if (!IsActive || amount <= 0) return;
            Balance += amount;
            Transactions.Add(new Transaction(DateTime.Now, "deposit", amount, AccountNumber));
        }

        public bool Withdraw(decimal amount)
        {
            if (!IsActive || amount <= 0 || amount > Balance) return false;
            Balance -= amount;
            Transactions.Add(new Transaction(DateTime.Now, "withdrawal", amount, AccountNumber));
            return true;
        }

        public void Close() => IsActive = false;

        public override string ToString() =>
            $"{AccountNumber} | {OwnerName} | {Balance} {Currency} | {AccountType} | {(IsActive ? "Aktywne" : "Zamknięte")}";
    }
}