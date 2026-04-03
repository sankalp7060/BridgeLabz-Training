using System;
using System.Collections.Generic;
using HealthCheckPro.Controllers;
using HealthCheckPro.Interfaces;
using HealthCheckPro.Services;

namespace HealthCheckPro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== HealthCheckPro - API Metadata Validator ===\n");

            // Register all controllers
            List<Type> controllers = new List<Type>
            {
                typeof(LabTestController),
                typeof(PatientController),
            };

            // Initialize service
            IHealthCheckService healthCheckService = new HealthCheckService(controllers);

            // Scan controllers
            var apiMethods = healthCheckService.ScanControllers();

            // Generate documentation
            healthCheckService.GenerateDocumentation(apiMethods);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
