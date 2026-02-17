using System;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Property)]
public class EmailValidationAttribute : Attribute
{
    private static readonly string EmailPattern =
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";

    public bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        return Regex.IsMatch(email, EmailPattern);
    }
}
