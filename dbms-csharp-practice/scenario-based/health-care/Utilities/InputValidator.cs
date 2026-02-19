using System;
using System.Text.RegularExpressions;

namespace HealthCareClinicSystem.Utilities
{
    public static class InputValidator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) && Regex.IsMatch(phone, @"^[0-9]{10}$");
        }

        public static bool IsValidDate(DateTime date)
        {
            return date >= DateTime.Today;
        }

        public static bool IsValidTime(TimeSpan time)
        {
            return time >= TimeSpan.FromHours(9) && time <= TimeSpan.FromHours(17);
        }

        public static string GetValidString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input cannot be empty. Please try again.");
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        public static int GetValidInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Please enter a valid number between {min} and {max}.");
            } while (true);
        }

        public static decimal GetValidDecimal(string prompt, decimal min = 0)
        {
            decimal result;
            do
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out result) && result >= min)
                    return result;
                Console.WriteLine($"Please enter a valid amount greater than {min}.");
            } while (true);
        }

        public static DateTime GetValidDate(string prompt, bool futureOnly = true)
        {
            DateTime result;
            do
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out result))
                {
                    if (!futureOnly || result >= DateTime.Today)
                        return result;
                    Console.WriteLine("Date cannot be in the past.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid date (yyyy-mm-dd).");
                }
            } while (true);
        }

        public static TimeSpan GetValidTime(string prompt)
        {
            TimeSpan result;
            do
            {
                Console.Write(prompt);
                if (
                    TimeSpan.TryParse(Console.ReadLine(), out result)
                    && result >= TimeSpan.FromHours(9)
                    && result <= TimeSpan.FromHours(17)
                )
                    return result;
                Console.WriteLine("Please enter a valid time between 09:00 and 17:00.");
            } while (true);
        }
    }
}
