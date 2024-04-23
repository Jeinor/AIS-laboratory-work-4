using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dfs
{
    public class Graph
    {
        //Создание графа
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

        internal void DFSHelper(int start, int finish, bool[] visited, ref int count)
        {
            visited[start] = true;
            Console.Write(start);
            if (linkedListArray[start] != null)
            {
                foreach (var item in linkedListArray[start])
                {
                    if (!visited[item] == true || start != finish)
                    {
                        Console.Write("->");
                        count++;
                        DFSHelper(item, finish, visited, ref count);

                    }
                }
            }
        }

        internal void DFS()
        {
            Console.WriteLine("DFS");
            Console.Write("Enter starting path a: ");
            int a;

            //Exception handling when the input parameters of vertices a and b take incorrect values.
            bool check_a = int.TryParse(Console.ReadLine(), out a);
            while (!check_a)
            {
                Console.WriteLine("You didn't enter a number");
                Console.Write("Enter correct path a: ");
                check_a = int.TryParse(Console.ReadLine(), out a);
            }

            Console.Write("Enter finishing path b: ");
            int b;
            bool check_b = int.TryParse(Console.ReadLine(), out b);
            while (!check_b)
            {
                Console.WriteLine("You didn't enter a number");
                Console.Write("Enter correct path b: ");
                check_b = int.TryParse(Console.ReadLine(), out b);
            }

            int count = 0;
            Console.Write("Path: ");
            bool[] visited = new bool[linkedListArray.Length + 1];
            DFSHelper(a, b, visited, ref count);
            Console.WriteLine("\nPath length: " + count);
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
