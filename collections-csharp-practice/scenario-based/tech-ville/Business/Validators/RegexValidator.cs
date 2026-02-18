using System.Text.RegularExpressions;

namespace TechVilleSmartCity.Business.Validators
{
    /// <summary>
    /// Regular Expression Validator
    /// Module 20: Regular Expressions for data validation
    /// </summary>
    public static class RegexValidator
    {
        // Email validation pattern
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        // Phone number validation (supports multiple formats)
        private static readonly Regex PhoneRegex = new Regex(
            @"^(\+?\d{1,3}[-.]?)?\(?\d{3}\)?[-.]?\d{3}[-.]?\d{4}$",
            RegexOptions.Compiled
        );

        // Citizen ID validation (TC-YYYY-XXXXX)
        private static readonly Regex CitizenIdRegex = new Regex(
            @"^TC-\d{4}-[A-F0-9]{8}$",
            RegexOptions.Compiled
        );

        // Password strength validation
        private static readonly Regex PasswordRegex = new Regex(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            RegexOptions.Compiled
        );

        // PIN code validation (Indian PIN code format)
        private static readonly Regex PinCodeRegex = new Regex(@"^\d{6}$", RegexOptions.Compiled);

        // Date validation (YYYY-MM-DD)
        private static readonly Regex DateRegex = new Regex(
            @"^\d{4}-\d{2}-\d{2}$",
            RegexOptions.Compiled
        );

        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) && PhoneRegex.IsMatch(phone);
        }

        public static bool IsValidCitizenId(string citizenId)
        {
            return !string.IsNullOrWhiteSpace(citizenId) && CitizenIdRegex.IsMatch(citizenId);
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && PasswordRegex.IsMatch(password);
        }

        public static bool IsValidPinCode(string pinCode)
        {
            return !string.IsNullOrWhiteSpace(pinCode) && PinCodeRegex.IsMatch(pinCode);
        }

        public static bool IsValidDate(string date)
        {
            return !string.IsNullOrWhiteSpace(date) && DateRegex.IsMatch(date);
        }

        /// <summary>
        /// Extract PIN code from address using regex
        /// </summary>
        public static string ExtractPinCode(string address)
        {
            var match = Regex.Match(address, @"\b\d{6}\b");
            return match.Success ? match.Value : null;
        }

        /// <summary>
        /// Format phone number to standard format
        /// </summary>
        public static string FormatPhoneNumber(string phone)
        {
            // Remove all non-digit characters
            var digits = Regex.Replace(phone, @"\D", "");

            if (digits.Length == 10)
            {
                return Regex.Replace(digits, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
            }
            else if (digits.Length == 11 && digits.StartsWith("1"))
            {
                return Regex.Replace(digits, @"1(\d{3})(\d{3})(\d{4})", "1 ($1) $2-$3");
            }
            else if (digits.Length == 12)
            {
                return Regex.Replace(digits, @"(\d{2})(\d{3})(\d{3})(\d{4})", "+$1 ($2) $3-$4");
            }

            return phone; // Return original if can't format
        }
    }
}
