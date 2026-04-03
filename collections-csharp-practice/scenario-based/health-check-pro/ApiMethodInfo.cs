using System;
using System.Collections.Generic;

namespace HealthCheckPro.Domain.Models
{
    public class ApiMethodInfo
    {
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public List<string> Annotations { get; set; } = new List<string>();
        public bool MissingRequiredAnnotation { get; set; } = false;

        public override string ToString()
        {
            string annotations = string.Join(", ", Annotations);
            return $"{ControllerName}.{MethodName} [Annotations: {annotations}] MissingRequired: {MissingRequiredAnnotation}";
        }
    }
}
