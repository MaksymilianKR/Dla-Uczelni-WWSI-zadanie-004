using System;

namespace Lab1_Task.ConsoleApp
{
    public abstract class BankReport
    {
        public string Name { get; }
        public DateTime CreatedAt { get; }

        protected BankReport(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }

        public abstract void Generate(BankSystem bankSystem);

        public virtual void PrintHeader()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine($"Raport: {Name}");
            Console.WriteLine($"Utworzono: {CreatedAt}");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||");
        }
    }
}
