using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class RoleAllowedAttribute : Attribute
{
    public string Role;

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

class SecureService
{
    [RoleAllowed("ADMIN")]
    public void DeleteData()
    {
        Console.WriteLine("Data Deleted");
    }
}

class RoleBasedAccess
{
    static void Main()
    {
        string currentUserRole = "USER";

        MethodInfo m = typeof(SecureService).GetMethod("DeleteData");

        var attr = (RoleAllowedAttribute)
            Attribute.GetCustomAttribute(m, typeof(RoleAllowedAttribute));

        if (attr.Role == currentUserRole)
        {
            m.Invoke(new SecureService(), null);
        }
        else
        {
            Console.WriteLine("Access Denied!");
        }
    }
}
