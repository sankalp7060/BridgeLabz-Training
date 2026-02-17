using System;
using System.Threading.Tasks;

public class SmsNotificationSender : INotificationSender
{
    public NotificationType Type => NotificationType.SMS;

    public async Task SendAsync(Notification notification)
    {
        await Task.Delay(300); // simulate sending
        Console.WriteLine($"SMS sent to {notification.Recipient}: {notification.Message}");
    }
}
