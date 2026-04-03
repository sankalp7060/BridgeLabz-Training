using System;

namespace HealthCareClinicSystem.Services
{
    public static class AuthService
    {
        private const string AdminPassword = "smartcity@7060";
        public static string CurrentUserRole { get; private set; } = "";
        public static bool IsAuthenticated { get; private set; } = false;

        public static bool Login(string role, string password)
        {
            if (role.ToLower() == "admin" && password == AdminPassword)
            {
                CurrentUserRole = "Admin";
                IsAuthenticated = true;
                return true;
            }
            else if (role.ToLower() == "receptionist")
            {
                // Receptionist login - any password works for demo
                CurrentUserRole = "Receptionist";
                IsAuthenticated = true;
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            CurrentUserRole = "";
            IsAuthenticated = false;
        }

        public static bool IsAdmin()
        {
            return CurrentUserRole == "Admin";
        }

        public static bool IsReceptionist()
        {
            return CurrentUserRole == "Receptionist";
        }

        public static void CheckAdminAccess()
        {
            if (!IsAdmin())
            {
                throw new UnauthorizedAccessException(
                    "This feature is only available to Administrators."
                );
            }
        }

        public static void CheckReceptionistAccess()
        {
            if (!IsReceptionist() && !IsAdmin())
            {
                throw new UnauthorizedAccessException(
                    "This feature is only available to Receptionists."
                );
            }
        }
    }
}
