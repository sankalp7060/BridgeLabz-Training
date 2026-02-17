using System;
using System.Reflection;

public class EmailValidatorService
{
    public static bool ValidateEmail(Student student, out string error)
    {
        error = null;

        var emailProp = typeof(Student).GetProperty("Email");
        var attr = (EmailValidationAttribute)
            Attribute.GetCustomAttribute(emailProp, typeof(EmailValidationAttribute));

        if (attr != null && !attr.IsValid(student.Email))
        {
            error = $"Invalid email format: {student.Email}";
            return false;
        }
        return true;
    }
}
