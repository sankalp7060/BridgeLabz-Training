using System.Collections.Generic;

namespace TechVille.DSA.DataStructures.Trees
{
    public class CityHierarchyTree
    {
        class Node
        {
            public string Name;
            public List<Node> Children = new List<Node>();

            public Node(string n)
            {
                Name = n;
            }
        }

        private Node root = new Node("Mayor");

        public void AddDepartment(string name)
        {
            root.Children.Add(new Node(name));
        }

        public void Display()
        {
            System.Console.WriteLine(root.Name);
            foreach (var c in root.Children)
                System.Console.WriteLine(" |- " + c.Name);
        }
    }
}
