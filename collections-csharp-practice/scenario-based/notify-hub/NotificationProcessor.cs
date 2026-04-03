using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public interface INotificationProcessor
{
    void Enqueue(Notification notification);
    Task ProcessAllAsync();
}

public class NotificationProcessor : INotificationProcessor
{
    private readonly ConcurrentQueue<Notification> _queue = new();
    private readonly List<INotificationSender> _senders;

    public NotificationProcessor(IEnumerable<INotificationSender> senders)
    {
        _senders = senders.ToList();
    }

    // Enqueue notification if valid
    public void Enqueue(Notification notification)
    {
        var validationErrors = Validate(notification);
        if (validationErrors.Any())
        {
            notification.Status = NotificationStatus.Failed;
            notification.FailureReason = string.Join(", ", validationErrors);
            Console.WriteLine($"Notification rejected: {notification.FailureReason}");
            return;
        }
        _queue.Enqueue(notification);
        Console.WriteLine($"Notification queued: {notification.NotificationId}");
    }

    // Process notifications concurrently
    public async Task ProcessAllAsync()
    {
        var notifications = _queue
            .ToList()
            .OrderByDescending(n => n.Priority)
            .ThenBy(n => n.CreatedTime)
            .ToList();

        _queue.Clear();

        var tasks = notifications.Select(ProcessNotificationAsync);
        await Task.WhenAll(tasks);
    }

    private async Task ProcessNotificationAsync(Notification notification)
    {
        try
        {
            var sender = _senders.FirstOrDefault(s => s.Type == notification.Type);
            if (sender == null)
                throw new Exception("No sender available for type " + notification.Type);

            await sender.SendAsync(notification);
            notification.Status = NotificationStatus.Sent;
        }
        catch (Exception ex)
        {
            notification.Status = NotificationStatus.Failed;
            notification.FailureReason = ex.Message;
            Console.WriteLine(
                $"Failed to send notification {notification.NotificationId}: {ex.Message}"
            );
        }
    }

    // Validate using attributes
    private List<string> Validate(Notification notification)
    {
        var errors = new List<string>();
        foreach (var prop in notification.GetType().GetProperties())
        {
            var value = prop.GetValue(notification);
            foreach (var attr in prop.GetCustomAttributes())
            {
                switch (attr)
                {
                    case RequiredAttribute _
                        when value == null || (value is string s && string.IsNullOrEmpty(s)):
                        errors.Add($"{prop.Name} is required");
                        break;

                    case MaxLengthAttribute maxAttr
                        when value is string str && str.Length > maxAttr.Length:
                        errors.Add($"{prop.Name} exceeds max length of {maxAttr.Length}");
                        break;

                    case EmailFormatAttribute _ when value is string email && !email.Contains("@"):
                        errors.Add($"{prop.Name} is not a valid email");
                        break;

                    case PriorityAttribute prioAttr
                        when value is int p && (p < prioAttr.Min || p > prioAttr.Max):
                        errors.Add($"{prop.Name} must be between {prioAttr.Min}-{prioAttr.Max}");
                        break;
                }
            }
        }
        return errors;
    }
}
