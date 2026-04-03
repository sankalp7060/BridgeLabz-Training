using System.Collections.Generic;
using TechVille.DSA.Models;

namespace TechVille.DSA.DataStructures.Hashing
{
    // Fast citizen lookup system
    public class CitizenHashMap
    {
        private Dictionary<int, Citizen> map = new Dictionary<int, Citizen>();

        public void Add(Citizen c)
        {
            map[c.Id] = c;
        }

        public Citizen Find(int id)
        {
            return map.ContainsKey(id) ? map[id] : null;
        }
    }
}
