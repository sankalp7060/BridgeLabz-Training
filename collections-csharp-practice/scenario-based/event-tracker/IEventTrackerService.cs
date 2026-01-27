using System.Collections.Generic;
using EventTracker.Domain.Models;

namespace EventTracker.Interfaces
{
    public interface IEventTrackerService
    {
        List<EventLog> ScanAndLogEvents();
        void ExportLogsToJson(List<EventLog> logs, string filePath);
    }
}
