using System;

public class Student
{
    public string FullName { get; set; }

    [EmailValidation]
    public string Email { get; set; }

    public DateTime RegistrationTime { get; set; } = DateTime.Now;
}
