using System;

namespace Lab1_Task.ConsoleApp
{
    public class CustomerReport : BankReport
    {
        public CustomerReport()
            : base("Raport klientów")
        {
        }

        public override void Generate(BankSystem bankSystem)
        {
            if (bankSystem.Customers.Count == 0)
            {
                Console.WriteLine("Brak klientów w systemie.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Lista klientów:");
            foreach (var c in bankSystem.Customers)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine();
        }

        public void PrintCustomerCount(BankSystem bankSystem)
        {
            Console.WriteLine($"Liczba klientów: {bankSystem.Customers.Count}");
        }
    }
}
