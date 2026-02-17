using System;
using System.Threading.Tasks;

public class AppAlertNotificationSender : INotificationSender
{
    public NotificationType Type => NotificationType.AppAlert;

    public async Task SendAsync(Notification notification)
    {
        await Task.Delay(200); // simulate sending
        Console.WriteLine($"App Alert sent to {notification.Recipient}: {notification.Message}");
    }
}
