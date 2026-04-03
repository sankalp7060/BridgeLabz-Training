using TechVille.DSA.DataStructures.LinkedLists;
using TechVille.DSA.Models;

namespace TechVille.DSA.Services
{
    // Uses linked list inside project logic
    public class CitizenNetworkService
    {
        private CitizenLinkedList network = new CitizenLinkedList();

        public void AddCitizen()
        {
            network.Add(new Citizen(1, "Rohan", 22));
            network.Add(new Citizen(2, "Amit", 25));
        }

        public void ShowNetwork()
        {
            network.Display();
        }
    }
}
