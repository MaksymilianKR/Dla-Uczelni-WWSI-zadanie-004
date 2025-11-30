using System;
using System.Collections.Generic;
using Lab1_Task.ConsoleApp.Interfaces;

namespace Lab1_Task.ConsoleApp.Services
{
    public class ConsoleNotificationSender<T> : INotificationSender<T>
        where T : INotifiableEntity
    {
        public void Send(T entity, string message)
        {
            Console.WriteLine($"[{DateTime.Now}] Wysyłam powiadomienie do: {entity.DisplayName}");
            Console.WriteLine($"Podsumowanie: {entity.GetNotificationSummary()}");
            Console.WriteLine($"Treść: {message}");
            Console.WriteLine();
        }

        public void SendMany(IEnumerable<T> entities, string message)
        {
            foreach (var entity in entities)
            {
                Send(entity, message);
            }
        }
    }
}
