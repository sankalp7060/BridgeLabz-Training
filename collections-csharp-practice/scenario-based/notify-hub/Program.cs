using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Setup senders
        var senders = new List<INotificationSender>
        {
            new EmailNotificationSender(),
            new SmsNotificationSender(),
            new AppAlertNotificationSender(),
        };

        var processor = new NotificationProcessor(senders);

        // Generate notifications
        var notifications = new List<Notification>
        {
            new Notification
            {
                Recipient = "alice@example.com",
                Message = "Welcome!",
                Priority = 5,
                Type = NotificationType.Email,
            },
            new Notification
            {
                Recipient = "bob@example.com",
                Message = "Hello!",
                Priority = 2,
                Type = NotificationType.SMS,
            },
            new Notification
            {
                Recipient = "invalidemail",
                Message = "Oops",
                Priority = 3,
                Type = NotificationType.AppAlert,
            },
            new Notification
            {
                Recipient = "charlie@example.com",
                Message = "High priority alert",
                Priority = 5,
                Type = NotificationType.AppAlert,
            },
        };

        // Enqueue notifications
        foreach (var n in notifications)
            processor.Enqueue(n);

        // Process concurrently
        await processor.ProcessAllAsync();
    }
}
