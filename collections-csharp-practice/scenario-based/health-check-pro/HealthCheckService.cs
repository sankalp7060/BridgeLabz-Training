using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HealthCheckPro.Domain.Attributes;
using HealthCheckPro.Domain.Models;
using HealthCheckPro.Interfaces;

namespace HealthCheckPro.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly List<Type> _controllerTypes;

        public HealthCheckService(List<Type> controllerTypes)
        {
            _controllerTypes = controllerTypes;
        }

        public List<ApiMethodInfo> ScanControllers()
        {
            var apiMethods = new List<ApiMethodInfo>();

            foreach (var controller in _controllerTypes)
            {
                foreach (
                    var method in controller.GetMethods(
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
                    )
                )
                {
                    var annotations = method
                        .GetCustomAttributes()
                        .Select(a => a.GetType().Name.Replace("Attribute", ""))
                        .ToList();
                    var missingRequired =
                        !annotations.Contains("PublicAPI") && !annotations.Contains("RequiresAuth");

                    apiMethods.Add(
                        new ApiMethodInfo
                        {
                            ControllerName = controller.Name,
                            MethodName = method.Name,
                            Annotations = annotations,
                            MissingRequiredAnnotation = missingRequired,
                        }
                    );
                }
            }

            return apiMethods;
        }

        public void GenerateDocumentation(List<ApiMethodInfo> apiMethods)
        {
            Console.WriteLine("\n=== API Documentation ===\n");
            foreach (var method in apiMethods)
            {
                Console.WriteLine(method);
            }

            Console.WriteLine("\nDocumentation generation completed.");
        }
    }
}
