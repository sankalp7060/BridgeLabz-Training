using System;

namespace EventTracker.Domain.Models
{
    public class EventLog
    {
        public string Timestamp { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp}] {ClassName}.{MethodName} - {Description} | Metadata: {Metadata}";
        }
    }
}
