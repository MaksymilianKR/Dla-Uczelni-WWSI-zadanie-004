using System.Collections.Generic;
using Lab1_Task.ConsoleApp.Interfaces;

namespace Lab1_Task.ConsoleApp
{
    public class Customer : INotifiableEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Pesel { get; set; }

        public List<BankAccount> Accounts { get; } = new();

        public string DisplayName => $"{FirstName} {LastName}";

        public string GetNotificationSummary()
        {
            int count = Accounts?.Count ?? 0;
            return $"Klient: {DisplayName}, liczba kont: {count}";
        }

        public override string ToString() =>
            $"{FirstName} {LastName} | PESEL: {Pesel} | Email: {Email}";
    }
}
