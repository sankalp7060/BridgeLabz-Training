using System;

namespace HealthCheckPro.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PublicAPIAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresAuthAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class DeprecatedAPIAttribute : Attribute { }
}
