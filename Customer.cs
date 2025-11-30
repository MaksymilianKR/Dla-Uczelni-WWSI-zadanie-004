namespace Lab1_Task.ConsoleApp
{
    public class Customer
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Pesel { get; set; }

        public override string ToString() =>
            $"{FirstName} {LastName} | PESEL: {Pesel} ; Email: {Email}";
    }
}
