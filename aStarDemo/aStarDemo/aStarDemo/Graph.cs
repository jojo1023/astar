using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStarDemo
{
    class Graph<T> 
    {
        private List<Node<T>> verties = new List<Node<T>>();
        public List<Node<T>> Verties
        {
            get
            {
                return verties;
            }
            set
            {
                verties = value;
            }
        }
        public Graph()
        {

        }
        public Graph(List<Node<T>> initialNodes)
        {
            verties = initialNodes;
        }

        public void AddNode(Node<T> node)
        {
            verties.Add(node);
        }

        public void AddNodes(List<Node<T>> newNodes)
        {
            verties.AddRange(newNodes);
        }

        public void AddEdge(Node<T> node1, Node<T> node2, bool diagonalNeighbor)
        {
            node1.AddEdge(node2, diagonalNeighbor);
            node2.AddEdge(node1, diagonalNeighbor);
        }

        public void RemoveVertex(Node<T> node)
        {
            verties.Remove(node);
        }

        public void unVisit()
        {
            for(int i = 0; i < verties.Count; i++)
            {
                verties[i].Visited = false;
            }
        }

        

        public string Traverse(Node<T> root)
        {
            StringBuilder returnSB = new StringBuilder();

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            root.Visited = true;

            while (queue.Count > 0)
            {

                Node<T> current = queue.Dequeue();
                
                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (current.Neighbors[i].Visited != true)
                    {
                        queue.Enqueue(current.Neighbors[i]);
                        current.Neighbors[i].Visited = true;
                    }
                }
                returnSB.Append(current.Value);
            }
            unVisit();
            return returnSB.ToString();
        }
    }
}
