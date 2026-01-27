using System;
using System.Collections.Generic;
using EventTracker.Controllers;
using EventTracker.Domain.Models;
using EventTracker.Interfaces;
using EventTracker.Services;

namespace EventTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EventTracker - Auto Audit System ===\n");

            // Register classes to scan
            List<Type> classesToScan = new List<Type>
            {
                typeof(UserController),
                typeof(FileController),
            };

            IEventTrackerService trackerService = new EventTrackerService(classesToScan);

            // Scan classes and generate event logs
            List<EventLog> logs = trackerService.ScanAndLogEvents();

            // Print logs to console
            Console.WriteLine("Event Logs:");
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }

            // Export logs to JSON
            trackerService.ExportLogsToJson(logs, "EventLogs.json");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
