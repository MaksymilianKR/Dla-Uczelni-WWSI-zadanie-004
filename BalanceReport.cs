using System;
using System.Linq;

namespace Lab1_Task.ConsoleApp
{
    public class BalanceReport : BankReport
    {
        public string Currency { get; }

        public BalanceReport(string currency)
            : base($"Raport sald w walucie {currency}")
        {
            Currency = currency;
        }

        public override void Generate(BankSystem bankSystem)
        {
            var total = BankAccountHelpers.CalculateTotalBalance(bankSystem.Accounts, Currency);
            Console.WriteLine($"Suma środków w {Currency}: {total} {Currency}");
            Console.WriteLine();

            PrintAccounts(bankSystem);
        }

        public void PrintAccounts(BankSystem bankSystem)
        {
            Console.WriteLine($"Konta w walucie {Currency}:");
            foreach (var acc in bankSystem.Accounts.Where(a => a.Currency == Currency))
            {
                Console.WriteLine(acc.ToShortInfo());
            }
            Console.WriteLine();
        }

        public override void PrintHeader()
        {
            Console.WriteLine("********** RAPORT SALD **********");
            Console.WriteLine($"Waluta: {Currency}");
            Console.WriteLine($"Utworzono: {CreatedAt}");
            Console.WriteLine("*********************************");
        }
    }
}
