using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs
{
    public class Graph
    {
        LinkedList<int>[] linkedListArray;

        public Graph(int v)
        {
            linkedListArray = new LinkedList<int>[v];
        }

        public void AddEdge(int u, int v, bool blnBiDir = true)
        {
            if (linkedListArray[u] == null)
            {
                linkedListArray[u] = new LinkedList<int>();
                linkedListArray[u].AddFirst(v);
            }
            else
            {
                var last = linkedListArray[u].Last;
                linkedListArray[u].AddAfter(last, v);
            }

            if (blnBiDir)
            {
                if (linkedListArray[v] == null)
                {
                    linkedListArray[v] = new LinkedList<int>();
                    linkedListArray[v].AddFirst(u);
                }
                else
                {
                    var last = linkedListArray[v].Last;
                    linkedListArray[v].AddAfter(last, u);
                }
            }
        }

        internal void DFSHelper(int src, bool[] visited)
        {
            visited[src] = true;
            Console.Write(src);
            if (linkedListArray[src] != null)
            {
                foreach (var item in linkedListArray[src])
                {
                    if (!visited[item] == true)
                    {
                        Console.Write("->");
                        DFSHelper(item, visited);
                    }
                }
            }
        }

        internal void DFS()
        {
            Console.WriteLine("DFS");
            Console.Write("Path: ");
            bool[] visited = new bool[linkedListArray.Length + 1];
            DFSHelper(1, visited);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Graph graph = new Graph(5);
            graph.AddEdge(4, 2, false);
            graph.AddEdge(1, 3, false);
            graph.AddEdge(2, 4, false);
            graph.DFS();
            Console.ReadKey();
        }
    }
}
