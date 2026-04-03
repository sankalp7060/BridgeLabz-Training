using System.Text.RegularExpressions;

namespace Code;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (password == null) return false;
        if (password.Length < 8) return false;
        if (!Regex.IsMatch(password, "[A-Z]")) return false;
        if (!Regex.IsMatch(password, "[0-9]")) return false;
        return true;
    }
}
