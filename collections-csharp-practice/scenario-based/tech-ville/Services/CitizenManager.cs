using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Implements ICitizenManager.
    ///
    /// This class demonstrates heavy usage of:
    /// - List<T>
    /// - Queue<T>
    /// - Stack<T>
    /// - Dictionary<TKey,TValue>
    /// - LINQ (Sorting & Searching)
    /// </summary>
    public class CitizenManager : ICitizenManager
    {
        // Stores all citizens
        private List<Citizen> citizens = new List<Citizen>();

        // Fast lookup using ID
        private Dictionary<int, Citizen> citizenLookup = new Dictionary<int, Citizen>();

        // Service request queue (FIFO)
        private Queue<ServiceRequest> serviceQueue = new Queue<ServiceRequest>();

        // Undo stack (LIFO)
        private Stack<Citizen> undoStack = new Stack<Citizen>();

        /// <summary>
        /// Registers a new citizen.
        /// Demonstrates List and Dictionary usage.
        /// </summary>
        public void RegisterCitizen(Citizen citizen)
        {
            citizens.Add(citizen);
            citizenLookup[citizen.CitizenId] = citizen;
            undoStack.Push(citizen);

            Console.WriteLine("Citizen registered successfully.");
        }

        /// <summary>
        /// Displays all registered citizens.
        /// </summary>
        public void ViewAllCitizens()
        {
            foreach (var c in citizens)
            {
                Console.WriteLine($"{c.CitizenId} - {c.Name} - {c.City} - {c.Age}");
            }
        }

        /// <summary>
        /// Searches citizens by city using LINQ Where.
        /// </summary>
        public void SearchByCity(string city)
        {
            var result = citizens.Where(c => c.City.ToLower() == city.ToLower());

            foreach (var c in result)
            {
                Console.WriteLine($"{c.Name} - {c.City}");
            }
        }

        /// <summary>
        /// Sorts citizens alphabetically by name.
        /// </summary>
        public void SortByName()
        {
            var sorted = citizens.OrderBy(c => c.Name);

            foreach (var c in sorted)
            {
                Console.WriteLine($"{c.Name} - {c.City}");
            }
        }

        /// <summary>
        /// Adds a service request to queue (FIFO).
        /// </summary>
        public void AddToServiceQueue(ServiceRequest request)
        {
            serviceQueue.Enqueue(request);
            Console.WriteLine("Service request added to queue.");
        }

        /// <summary>
        /// Processes next request in queue.
        /// </summary>
        public void ProcessNextRequest()
        {
            if (serviceQueue.Count > 0)
            {
                var request = serviceQueue.Dequeue();
                Console.WriteLine($"Processing {request.ServiceType} for {request.Citizen.Name}");
            }
            else
            {
                Console.WriteLine("No pending requests.");
            }
        }

        /// <summary>
        /// Undo last citizen registration using Stack.
        /// </summary>
        public void UndoLastRegistration()
        {
            if (undoStack.Count > 0)
            {
                var citizen = undoStack.Pop();
                citizens.Remove(citizen);
                citizenLookup.Remove(citizen.CitizenId);

                Console.WriteLine("Last registration undone.");
            }
            else
            {
                Console.WriteLine("Nothing to undo.");
            }
        }

        /// <summary>
        /// Counts number of citizens per city.
        /// Demonstrates LINQ GroupBy.
        /// </summary>
        public void CountByCity()
        {
            var grouped = citizens.GroupBy(c => c.City);

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} : {group.Count()} citizens");
            }
        }
    }
}
