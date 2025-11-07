using System;

namespace Lab1_Task.ConsoleApp
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }   
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }

        public Transaction(DateTime date, string type, decimal amount, string accountNumber)
        {
            Date = date;
            Type = type;
            Amount = amount;
            AccountNumber = accountNumber;
        }

        public override string ToString() =>
            $"{Date:G} | {Type,-10} | {Amount,8:C} | Konto: {AccountNumber}";
    }
}
