using System;

public enum NotificationType
{
    Email,
    SMS,
    AppAlert,
}

public enum NotificationStatus
{
    Pending,
    Sent,
    Failed,
}

public class Notification
{
    [Required]
    public Guid NotificationId { get; set; } = Guid.NewGuid();

    [Required, EmailFormat]
    public string Recipient { get; set; }

    [Required, MaxLength(500)]
    public string Message { get; set; }

    [Priority(1, 5)]
    public int Priority { get; set; } = 3;

    public NotificationType Type { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

    public string FailureReason { get; set; }
}
