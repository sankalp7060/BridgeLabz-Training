using System;
using EventTracker.Domain.Attributes;

namespace EventTracker.Controllers
{
    public class UserController
    {
        [AuditTrail("User login action")]
        public void Login(string username)
        {
            Console.WriteLine($"{username} logged in.");
        }

        [AuditTrail("User logout action")]
        public void Logout(string username)
        {
            Console.WriteLine($"{username} logged out.");
        }

        public void HelperMethod()
        {
            // Not audited
        }
    }
}
