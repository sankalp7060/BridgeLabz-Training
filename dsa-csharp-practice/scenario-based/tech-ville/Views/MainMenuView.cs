using System;
using TechVille.DSA.Services;

namespace TechVille.DSA.Views
{
    // Entire project flow controlled from View
    public class MainMenuView
    {
        CitizenNetworkService network = new CitizenNetworkService();
        ServiceQueueManager queue = new ServiceQueueManager();

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== TechVille DSA Menu ===");
                Console.WriteLine("1. Citizen Network (Linked List)");
                Console.WriteLine("2. Service Queues");
                Console.WriteLine("0. Exit");

                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        network.AddCitizen();
                        network.ShowNetwork();
                        break;

                    case 2:
                        queue.AddRequests();
                        queue.Process();
                        break;

                    case 0:
                        running = false;
                        break;
                }
            }
        }
    }
}
