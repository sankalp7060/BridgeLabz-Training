using System;
using System.Threading.Tasks;

// Email Sender
public class EmailNotificationSender : INotificationSender
{
    public NotificationType Type => NotificationType.Email;

    public async Task SendAsync(Notification notification)
    {
        await Task.Delay(500); // simulate sending
        Console.WriteLine($"Email sent to {notification.Recipient}: {notification.Message}");
    }
}
