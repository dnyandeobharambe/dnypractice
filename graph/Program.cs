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
            Console.WriteLine("Graph AdjList  ");
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
            Console.WriteLine("Graph AdjMatrix  ");
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

            Thread.Sleep(5000);

            Console.WriteLine("Tree InOrder input as 1 2 3 4 5  ");
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.Inorder();

           

            Thread.Sleep(5000);
            Console.WriteLine("PreOrder input 10 8 2 3 5 2");
            //BinaryTree tree1 = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(2);
            tree.PreOrder();

            Thread.Sleep(5000);
            Console.WriteLine("PostOrder input 10 8 2 3 5 2");
            //BinaryTree tree1 = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(2);
            tree.PostOrder();

            Thread.Sleep(5000);

            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(6);

            tree.LevelOrder(root);

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

    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;
        public virtual void Inorder()
        {
            if (root == null)
                return;

            Stack<Node> st = new Stack<Node>();
            Node curr = root;

           while(curr != null || st.Count > 0)
            {
                while(curr != null)
                {
                    st.Push(curr);
                    curr = curr.left;
                }
                curr = st.Pop();
                Console.WriteLine(curr.data + "Inorder" + " ");
                curr = curr.right;
            }

           

        }

        //https://www.geeksforgeeks.org/iterative-preorder-traversal/
           

        public virtual void PreOrder()
        {
            if(root == null)
            {
                return;
            }
            Stack<Node> st = new Stack<Node>();
            st.Push(root);
            while(st.Count > 0)
            {
                Node curr = st.Peek();
                Console.Write(curr.data + " ");
                st.Pop();
                if(curr.right != null)
                {
                    st.Push(curr.right);
                }
                if (curr.left != null)
                {
                    st.Push(curr.left);
                }
            }
        }

        public virtual void PostOrder()
        {
            List<int> res = new List<int>();
            Stack<Node> st = new Stack<Node>();
            if (root == null) return;
            st.Push(root);
            while(st.Count > 0)
            {
               
                Node curr = st.Pop();
                res.Insert(0, curr.data);
                if(curr.left != null)
                {
                    st.Push(curr.left);
                }
                if(curr.right != null)
                {
                    st.Push(curr.right);
                }

            }

            foreach(int i in res)
            {
                Console.WriteLine("Postorder is   " + i);
            }

        }

        public virtual void LevelOrder(Node root)
        {
            if(root == null)
            {
                return;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                Node curr = q.Dequeue();
                Console.WriteLine("level order is   " + curr.data);
                if(curr.left != null)
                {
                    q.Enqueue(curr.left);
                }
                if(curr.right != null)
                {
                    q.Enqueue(curr.right);
                }

            }

        }
    }
}
