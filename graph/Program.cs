using System;
using System.Collections.Generic;
using System.Threading;

//refer other graph algo at 
//https://www.programiz.com/dsa/graph-dfs
namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = 5;
            Graph g = new Graph(5);
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);
            g.AddEdge(1,2);
            g.AddEdge(1,3);
            g.AddEdge(1,4);
            g.AddEdge(2,3);
            g.AddEdge(3,4);
            g.PrintList();

            Thread.Sleep(5000);

            GraphAsMatrix g1 = new GraphAsMatrix(5);

            g1.AddEdge(0, 1);
            g1.AddEdge(0, 4);
            g1.AddEdge(1, 2);
            g1.AddEdge(1, 3);
            g1.AddEdge(1, 4);
            g1.AddEdge(2, 3);
            g1.AddEdge(3, 4);
            g1.PrintGraph();

            Thread.Sleep(5000);

            GraphTraval graph = new GraphTraval(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            //Print adjacency matrix
            graph.PrintAdjacecnyMatrix();

            Console.WriteLine("BFS traversal starting from vertex 2:");
            graph.BFS(2);
            Console.WriteLine("DFS traversal starting from vertex 2:");
            graph.DFS(2);

            Console.ReadLine();


        }



       
    }

    public class Graph
    {
        int v;
        List<List<int>> adjList;

        public Graph(int V)
        {
            v = V;
            adjList = new List<List<int>>(V);
            for(int i = 0;i < V;i++)
            {
                adjList.Add(new List<int>());
            }

        }

        public void AddEdge(int u,int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        public void PrintList()
        {
            for(int i =0;i<adjList.Count;i++)
            {
                Console.WriteLine("Adjestary List of i is " +  i);
                for(int j = 0;j < adjList[i].Count;j++)
                {
                    Console.WriteLine(adjList[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

    }

    public class GraphAsMatrix
    {
        int v;
        int[,] matrix;

        public GraphAsMatrix(int V)
        {
            v = V;
            matrix = new int[V, V];

        }

        public void AddEdge(int source, int dest)
        {
            matrix[source, dest] = 1;
            matrix[dest, source] = 1;
        }

        public void PrintGraph()
        {
            Console.WriteLine("Graph: (Adjacency Matrix)");
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.WriteLine(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("Vertex " + i + " is connected to:");
                for (int j = 0; j < v; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        Console.WriteLine(j + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }

    public class GraphTraval
    {
        int v;
        List<List<int>> adjList;
        /* Example : vertices=4
        *      0->[1,2]
        *      1->[2]
        *      2->[0,3]
        *      3->[]
        */
        public GraphTraval(int V)
        {
            v = V;
            adjList = new List<List<int>>(V);
            for (int i = 0; i < V; i++)
            {
                adjList.Add(new List<int>());
            }
        }

        public void AddEdge(int source, int dest)
        {
            adjList[source].Add(dest);
            adjList[source].Add(dest);
        }

        public void DFS(int start)
        {
            bool[] visited = new bool[v];
            Stack<int> st = new Stack<int>();
            visited[start] = true;
            st.Push(start);
            while(st.Count > 0)
            {
                start = st.Pop();
                Console.WriteLine("next-->"  + start);
                foreach (int i in adjList[start])
                {
                    if(!visited[i])
                    {
                        visited[i] = true;
                        st.Push(i);
                    }
                }

            }


        }

        public void BFS(int start)
        {
            bool[] visited = new bool[v];
            Queue<int> q = new Queue<int>();
            visited[start] = true;
            q.Enqueue(start);
            while(q.Count > 0)
            {
                start = q.Dequeue();
                Console.WriteLine("next-->" + start);
                foreach(int next in adjList[start])
                {
                    if(!visited[next])
                    {
                        visited[next] = true;
                        q.Enqueue(next);
                    }
                }
            }
        }

        public void PrintAdjacecnyMatrix()
        {
            for (int i = 0; i < v; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adjList[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }

    }
}
