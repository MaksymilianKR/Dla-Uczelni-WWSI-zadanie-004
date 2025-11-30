namespace Lab1_Task.ConsoleApp
{
    public static class BankAccountExtensions
    {
        public static string ToShortInfo(this BankAccount account)
        {
            string owner = account.Owner != null
                ? $"{account.Owner.FirstName} {account.Owner.LastName}"
                : account.OwnerName;

            return $"{account.AccountNumber} | {owner} | {account.Balance} {account.Currency}";
        }
    }
}
