using TechVille.Core.Interfaces;

namespace TechVille.Core.Services
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LOG]: {DateTime.Now} - {message}");
            Console.ResetColor();
        }
    }
}
