using System;
using System.IO;
using System.Text;

namespace TechVilleSmartCity.Utilities
{
    /// <summary>
    /// Exception logging utility
    /// Module 5: Error logging
    /// Module 19: Comprehensive exception management
    /// </summary>
    public static class ExceptionLogger
    {
        private static readonly string logDirectory = "Logs";
        private static readonly string logFile = "error.log";
        private static readonly object lockObject = new object();

        static ExceptionLogger()
        {
            // Ensure log directory exists
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public static void LogException(Exception ex, string source = null)
        {
            try
            {
                lock (lockObject)
                {
                    var logEntry = new StringBuilder();
                    logEntry.AppendLine($"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    logEntry.AppendLine($"Source: {source ?? "Unknown"}");
                    logEntry.AppendLine($"Exception Type: {ex.GetType().FullName}");
                    logEntry.AppendLine($"Message: {ex.Message}");
                    logEntry.AppendLine($"Stack Trace: {ex.StackTrace}");

                    if (ex.InnerException != null)
                    {
                        logEntry.AppendLine($"Inner Exception: {ex.InnerException.Message}");
                    }

                    logEntry.AppendLine(new string('-', 80));

                    string logPath = Path.Combine(logDirectory, logFile);
                    File.AppendAllText(logPath, logEntry.ToString());
                }
            }
            catch
            {
                // Silently fail if logging fails - don't crash the application
            }
        }

        public static string GetRecentLogs(int lineCount = 50)
        {
            try
            {
                string logPath = Path.Combine(logDirectory, logFile);
                if (!File.Exists(logPath))
                    return "No logs found.";

                var lines = File.ReadAllLines(logPath);
                var startIndex = Math.Max(0, lines.Length - lineCount);
                return string.Join(
                    Environment.NewLine,
                    lines,
                    startIndex,
                    lines.Length - startIndex
                );
            }
            catch
            {
                return "Error reading logs.";
            }
        }

        public static void ClearLogs()
        {
            try
            {
                string logPath = Path.Combine(logDirectory, logFile);
                if (File.Exists(logPath))
                {
                    File.Delete(logPath);
                }
            }
            catch
            {
                // Silently fail
            }
        }
    }
}
