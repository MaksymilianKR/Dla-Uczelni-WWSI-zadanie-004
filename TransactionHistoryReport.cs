using System;

namespace Lab1_Task.ConsoleApp
{
    public class TransactionHistoryReport : BankReport
    {
        public string AccountNumber { get; }

        public TransactionHistoryReport(string accountNumber)
            : base($"Historia transakcji dla konta {accountNumber}")
        {
            AccountNumber = accountNumber;
        }

        public override void Generate(BankSystem bankSystem)
        {
            var account = BankAccountHelpers.FindAccountByNumber(bankSystem.Accounts, AccountNumber);

            if (account == null)
            {
                Console.WriteLine($"Nie znaleziono konta o numerze {AccountNumber}");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"Konto: {account.ToShortInfo()}");
            Console.WriteLine("Transakcje:");
            if (account.Transactions.Count == 0)
            {
                Console.WriteLine("Brak transakcji.");
            }
            else
            {
                foreach (var t in account.Transactions)
                {
                    Console.WriteLine(t);
                }
            }
            Console.WriteLine();
        }


        public void PrintLastTransaction(BankSystem bankSystem)
        {
            var account = BankAccountHelpers.FindAccountByNumber(bankSystem.Accounts, AccountNumber);
            if (account == null || account.Transactions.Count == 0)
            {
                Console.WriteLine("Brak ostatniej transakcji do wyświetlenia!!");
                return;
            }

            var last = account.Transactions[^1];
            Console.WriteLine($"Ostatnia transakcja: {last}");
        }
    }
}
