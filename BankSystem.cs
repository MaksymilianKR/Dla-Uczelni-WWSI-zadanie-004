using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab1_Task.ConsoleApp
{
    public class BankSystem
    {
        private readonly List<BankAccount> _accounts = new();
        private readonly List<Customer> _customers = new();
        private const string FilePath = "accounts.json";


        public List<BankAccount> Accounts => _accounts;
        public List<Customer> Customers => _customers;

        public void AddAccount(BankAccount account) => _accounts.Add(account);

        public void AddCustomer(Customer customer) => _customers.Add(customer);

        public BankAccount? FindAccount(string accountNumber) =>
            _accounts.Find(a => a.AccountNumber == accountNumber);

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void LoadFromFile()
        {
            if (!File.Exists(FilePath)) return;
            string json = File.ReadAllText(FilePath);
            var data = JsonSerializer.Deserialize<List<BankAccount>>(json);
            if (data != null) _accounts.Clear();
            if (data != null) _accounts.AddRange(data);
        }

        public void DisplayAll()
        {
            foreach (var acc in _accounts)
                Console.WriteLine(acc);
        }
    }
}
