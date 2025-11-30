using System;
using System.Collections.Generic;
using System.Linq;
using Lab1_Task.ConsoleApp.Interfaces;
using Lab1_Task.ConsoleApp.Services;

namespace Lab1_Task.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankSystem bank = new();

            var customer1 = new Customer
            {
                FirstName = "Piotr",
                LastName = "Pan",
                Email = "piotr.pan@example.com",
                Pesel = "12345678901"
            };

            var customer2 = new Customer
            {
                FirstName = "Harry",
                LastName = "Potter",
                Email = "harry.potter@example.com",
                Pesel = "23456789012"
            };

            var customer3 = new Customer
            {
                FirstName = "John",
                LastName = "Wick",
                Email = "john.wick@example.com",
                Pesel = "34567890123"
            };

            bank.AddCustomer(customer1);
            bank.AddCustomer(customer2);
            bank.AddCustomer(customer3);

            BankAccount acc1 = new("001", $"{customer1.FirstName} {customer1.LastName}", 1000, "PLN", "Oszczędnościowe", "Złoty")
            {
                Owner = customer1
            };

            BankAccount acc2 = new("002", $"{customer2.FirstName} {customer2.LastName}", 2500, "PLN", "Standard", "Niebieski")
            {
                Owner = customer2
            };

            BankAccount acc3 = new("003", $"{customer3.FirstName} {customer3.LastName}", 150, "PLN", "Premium", "Czarny")
            {
                Owner = customer3
            };

            bank.AddAccount(acc1);
            bank.AddAccount(acc2);
            bank.AddAccount(acc3);

            customer1.Accounts.Add(acc1);
            customer2.Accounts.Add(acc2);
            customer3.Accounts.Add(acc3);

            acc1.Deposit(500);             
            acc2.Withdraw(300);            
            acc2.TransferTo(acc3, 200);     

            Console.WriteLine("Krótka informacja o kontach (ToShortInfo):");
            Console.WriteLine(acc1.ToShortInfo());
            Console.WriteLine(acc2.ToShortInfo());
            Console.WriteLine(acc3.ToShortInfo());
            Console.WriteLine();

            decimal totalPln = BankAccountHelpers.CalculateTotalBalance(bank.Accounts, "PLN");
            Console.WriteLine($"Suma środków w PLN (metoda statyczna): {totalPln} PLN");

            var found = BankAccountHelpers.FindAccountByNumber(bank.Accounts, "002");
            Console.WriteLine(found != null
                ? $"Znaleziono konto 002: {found.ToShortInfo()}"
                : "Nie znaleziono konta 002");
            Console.WriteLine();

            var customerNotificationSender = new ConsoleNotificationSender<Customer>();
            var accountNotificationSender = new ConsoleNotificationSender<BankAccount>();

            customerNotificationSender.Send(customer1, "Twoje nowe konto zostało utworzone.");

            var lowBalanceAccounts = bank.Accounts
                .Where(a => a.Balance < 1000m);

            accountNotificationSender.SendMany(lowBalanceAccounts,
                "Twoje saldo jest niższe niż 1000 PLN.");
            Console.WriteLine();

            INotificationSender<BankAccount> accountSender = new ConsoleNotificationSender<BankAccount>();
            INotificationSender<Customer> customerSender = new ConsoleNotificationSender<Customer>();

            customerSender.Send(customer2, "Dziękujemy za skorzystanie z naszej oferty!");
            accountSender.Send(acc3, "Twoja ostatnia transakcja została zaksięgowana.");

            var entities = new List<INotifiableEntity>
            {
                customer1, customer2, customer3,
                acc1, acc2, acc3
            };

            Console.WriteLine("=== Lista wszystkich powiadamialnych encji ===");
            foreach (var e in entities)
            {
                Console.WriteLine($"DisplayName: {e.DisplayName}");
                Console.WriteLine($"Summary: {e.GetNotificationSummary()}");
                Console.WriteLine();
            }

            List<BankReport> reports = new List<BankReport>
            {
                new BalanceReport("PLN"),
                new TransactionHistoryReport("002"),
                new CustomerReport()
            };

            foreach (var report in reports)
            {
                report.PrintHeader();
                report.Generate(bank);
            }

            bank.SaveToFile();
            Console.WriteLine("\nDane zapisano do pliku accounts.json");

            Console.WriteLine("\nNaciśnij Enter, aby zakończyć...");
            Console.ReadLine();
        }
    }
}
