namespace Lab1_Task.ConsoleApp.Interfaces
{
    public interface INotifiableEntity
    {
        string DisplayName { get; }
        string GetNotificationSummary();
    }
}
