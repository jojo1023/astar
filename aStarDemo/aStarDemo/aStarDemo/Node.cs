using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStarDemo
{
    class Node<T>
    {
        private List<NeighborTypes> neighborTypes = new List<NeighborTypes>();
        private List<Node<T>> neighbors = new List<Node<T>>();
        private bool visited;
        private T val;
        public T Value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
        public bool Visited
        {
            get
            {
                return visited;
            }
            set
            {
                visited = value;
            }
        }
        public List<Node<T>> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }


        public Node(T val)
        {
            this.val = val;
            visited = false;
        }


        public void AddEdge(Node<T> newNode, bool diagonalNeighbor)
        {
            if (!neighbors.Contains(newNode))
            {
                neighbors.Add(newNode);
                if (diagonalNeighbor)
                {
                    neighborTypes.Add(NeighborTypes.DiagonalNeighbor);
                }
                else
                {
                    neighborTypes.Add(NeighborTypes.SideNeighbor);
                }
            }
        }

        public void RemoveNode(Node<T> node)
        {
            neighbors.Remove(node);
        }



    }
}
