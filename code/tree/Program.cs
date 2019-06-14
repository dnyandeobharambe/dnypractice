using System;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Tree t = new Tree();
            int[] testArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //t.ArrayToTree(testArr, 0);
            //t.Print(t.ArrayToTree(testArr,0));
            t.ArrayToTree(testArr, 0);
            t.Print(t.AddRootWithChild(1, t.AddRoot(2), t.AddRoot(3)));
            t.Print(t.AddChildern(t.AddRoot(2), t.AddRoot(4), t.AddRoot(5)));
            Console.Read();

        }
    }

    public class Tree
    {
       public class Node
        {
            internal int val;
            internal Node lChild;
            internal Node rChild;

            public Node(int v, Node left,Node right)
            {
                val = v;
                lChild = left;
                rChild = right;
            }

            public Node(int v)
            {
                val = v;
                lChild = null;
                rChild = null;
            }
        }

        private Node root;

        public Tree()
        {
            root = null;
        }

        public Node AddRoot(int data)
        {
          return new Node(data);
            
        }

        public Node AddRootWithChild(int data,Node l,Node r)
        {
            root = new Node(data, l, r);
            return root;
            
        }

        public Node AddChildern(Node parent, Node l, Node r)
        {
            parent.lChild = l;
            parent.rChild = r;
            return parent;
        }

        public void Print(Node newNode)
        {
            Node temp = newNode;
            Node temp1 = newNode;
            Console.WriteLine("Root :" + temp.val);
            while(temp != null)
            {
                
                Console.WriteLine("LeftNodes :" + temp.val);
                temp = temp.lChild;
              

            }
            while (temp1 != null)
            {
                Console.WriteLine("RightNodes :" + temp1.val);
                temp1 = temp1.rChild;

            }

        }

        //public void Print()
        //{
        //    Node temp = root;
        //    Node temp1 = root;
        //    Console.WriteLine("Root :" + temp.val);
        //    while (temp != null)
        //    {

        //        Console.WriteLine("LeftNodes :" + temp.val);
        //        temp = temp.lChild;


        //    }
        //    while (temp1 != null)
        //    {
        //        Console.WriteLine("RightNodes :" + temp1.val);
        //        temp1 = temp1.rChild;

        //    }

        //}



        public Node ArrayToTree(int[] arr,int start)
        {
            int len = arr.Length;
            Node current = new Node(arr[start]);

            int left = 2 * start + 1;
            int right = 2 * start + 2;

            if (left < len)
            {
                current.lChild = ArrayToTree(arr, left);
            }
            if(right < len)
            {
               current.rChild =  ArrayToTree(arr, right);
            }
            Console.WriteLine(current.val);
            return current;


        }


        public void BFS()
        {
            Queue<Node> bfsQueue = new Queue<Node>();
            Node temp;

            if(root != null)
            {
                bfsQueue.Enqueue(root);
            }

            while(bfsQueue.Count  != 0)
            {
                temp = bfsQueue.Dequeue();
                Console.WriteLine(temp);

                if(temp.lChild != null)
                {
                    bfsQueue.Enqueue(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    bfsQueue.Enqueue(temp.rChild);
                }
            }

        }


        public void DFS()
        {
            Stack<Node> dfsStack = new Stack<Node>();
            Node temp;
            if(root != null)
            {
                dfsStack.Push(root);

            }

            while(dfsStack.Count != 0)
            {
                temp = dfsStack.Pop();
                if(temp.lChild != null)
                {
                    dfsStack.Push(temp.lChild);
                }
                if(temp.rChild != null)
                {
                    dfsStack.Push(temp.rChild);
                }
            }

        

            
        }


        public int TreeDepth(Node root)
        {
            if(root == null)
            {
                return 0;
            }
            else
            {
                int lDepth = TreeDepth(root.lChild);
                int rDepth = TreeDepth(root.rChild);

                if(lDepth > rDepth )
                {
                    return lDepth + 1;
                }
                else
                {
                    return rDepth + 1;
                }
            }
        }


        public int TreeLeaves(Node root)
        {
            if(root == null)
            {
                return 0;
            }
            if(root.lChild == null && root.rChild == null)
            {
                return 1;
            }
            else
            {
                return TreeLeaves(root.lChild) + TreeLeaves(root.rChild);
            }
        }

        public Boolean IsIsEqual(Node first,Node second)
        {
            if(first == null && second == null)
            {
                return true;
            }
            else if(first == null || second == null)
            {
                return false;
            }
            else
            {
                return ((IsIsEqual(first.lChild, second.lChild) && (IsIsEqual(first.rChild, second.rChild)) && first.val == second.val));
            }
        }
    }
}
