using System.Collections.Generic;
using TechVille.DSA.Models;

namespace TechVille.DSA.DataStructures.Queues
{
    // Standard service queue (FIFO)
    public class ServiceQueue
    {
        private Queue<ServiceRequest> queue = new Queue<ServiceRequest>();

        public void Enqueue(ServiceRequest r)
        {
            queue.Enqueue(r);
        }

        public ServiceRequest Dequeue()
        {
            return queue.Count > 0 ? queue.Dequeue() : null;
        }

        public void Display()
        {
            foreach (var q in queue)
                System.Console.WriteLine(q.ServiceName);
        }
    }
}
