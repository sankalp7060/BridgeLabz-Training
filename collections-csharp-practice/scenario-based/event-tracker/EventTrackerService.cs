using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EventTracker.Domain.Attributes;
using EventTracker.Domain.Models;
using EventTracker.Interfaces;
using Newtonsoft.Json;

namespace EventTracker.Services
{
    public class EventTrackerService : IEventTrackerService
    {
        private readonly List<Type> _classesToScan;

        public EventTrackerService(List<Type> classesToScan)
        {
            _classesToScan = classesToScan;
        }

        public List<EventLog> ScanAndLogEvents()
        {
            var eventLogs = new List<EventLog>();

            foreach (var type in _classesToScan)
            {
                var methods = type.GetMethods(
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
                );

                foreach (var method in methods)
                {
                    var auditAttr = method.GetCustomAttribute<AuditTrailAttribute>();
                    if (auditAttr != null)
                    {
                        var log = new EventLog
                        {
                            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            ClassName = type.Name,
                            MethodName = method.Name,
                            Description = auditAttr.Description,
                            Metadata = "N/A", // Can be extended for real metadata
                        };
                        eventLogs.Add(log);
                    }
                }
            }

            return eventLogs;
        }

        public void ExportLogsToJson(List<EventLog> logs, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(logs, options);
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"\nJSON logs exported to {filePath}");
        }
    }
}
