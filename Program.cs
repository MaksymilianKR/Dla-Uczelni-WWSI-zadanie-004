using System;

namespace Lab1_Task.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankSystem bank = new();

            BankAccount acc1 = new("001", "Piotruś Pan", 1000, "PLN", "Oszczędnościowe", "Złoty");
            BankAccount acc2 = new("002", "Harry Potter", 2500, "PLN", "Standard", "Niebieski");
            BankAccount acc3 = new("003", "Johny Wick", 150, "PLN", "Premium", "Czarny");

            bank.AddAccount(acc1);
            bank.AddAccount(acc2);
            bank.AddAccount(acc3);

            acc1.Deposit(500);
            acc2.Withdraw(300);

            bank.DisplayAll();
            bank.SaveToFile();

            Console.WriteLine("\nDane zapisano do pliku accounts.json");
        }
    }
}
