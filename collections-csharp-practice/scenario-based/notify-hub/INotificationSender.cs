using System.Threading.Tasks;

public interface INotificationSender
{
    NotificationType Type { get; }
    Task SendAsync(Notification notification);
}
