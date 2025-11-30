using System.Collections.Generic;
using System.Linq;

namespace Lab1_Task.ConsoleApp
{
    public static class BankAccountHelpers
    {
        public static decimal CalculateTotalBalance(IEnumerable<BankAccount> accounts, string currency)
        {
            return accounts
                .Where(a => a.Currency == currency)
                .Sum(a => a.Balance);
        }

        public static BankAccount? FindAccountByNumber(IEnumerable<BankAccount> accounts, string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}
