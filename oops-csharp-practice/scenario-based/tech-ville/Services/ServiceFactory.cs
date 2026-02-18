using System;

namespace TechVille.OOPS.Services
{
    // Factory Pattern using static method
    public static class ServiceFactory
    {
        public static Service CreateService(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new HealthcareService();
                case 2:
                    return new EducationService();
                case 3:
                    return new EmergencyService();
                default:
                    return null;
            }
        }
    }
}
