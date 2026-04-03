using System;
using EventTracker.Domain.Attributes;

namespace EventTracker.Controllers
{
    public class FileController
    {
        [AuditTrail("File upload action")]
        public void UploadFile(string fileName)
        {
            Console.WriteLine($"{fileName} uploaded.");
        }

        [AuditTrail("File delete action")]
        public void DeleteFile(string fileName)
        {
            Console.WriteLine($"{fileName} deleted.");
        }
    }
}
