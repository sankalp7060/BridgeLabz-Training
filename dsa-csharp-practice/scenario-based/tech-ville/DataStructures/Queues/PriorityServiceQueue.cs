using System.Collections.Generic;
using System.Linq;
using TechVille.DSA.Models;

namespace TechVille.DSA.DataStructures.Queues
{
    // Priority queue for emergency requests
    public class PriorityServiceQueue
    {
        private List<ServiceRequest> list = new List<ServiceRequest>();

        public void Add(ServiceRequest r)
        {
            list.Add(r);
            list = list.OrderByDescending(x => x.Priority).ToList();
        }

        public ServiceRequest Process()
        {
            if (list.Count == 0)
                return null;

            ServiceRequest r = list[0];
            list.RemoveAt(0);
            return r;
        }
    }
}
