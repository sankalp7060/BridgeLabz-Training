using System;

namespace Code;

public class DateFormatter
{
    public string FormatDate(string inputDate)
    {
        if (!DateTime.TryParse(inputDate, out var dt))
            throw new ArgumentException("Invalid date format");

        return dt.ToString("dd-MM-yyyy");
    }
}
