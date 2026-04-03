using System.Collections.Generic;
using HealthCheckPro.Domain.Models;

namespace HealthCheckPro.Interfaces
{
    public interface IHealthCheckService
    {
        List<ApiMethodInfo> ScanControllers();
        void GenerateDocumentation(List<ApiMethodInfo> apiMethods);
    }
}
