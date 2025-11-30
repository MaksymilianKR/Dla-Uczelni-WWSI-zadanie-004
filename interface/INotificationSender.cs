using System.Collections.Generic;

namespace Lab1_Task.ConsoleApp.Interfaces
{
    public interface INotificationSender<T> where T : INotifiableEntity
    {
        void Send(T entity, string message);
        void SendMany(IEnumerable<T> entities, string message);
    }
}
