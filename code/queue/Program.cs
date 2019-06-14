using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class OptimizeEnque
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        internal void Enque(int num)
        {
            stack1.Push(num);
        }

        internal int Deque()
        {
            if(stack2.Count == 0)
            {
                while(stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }
    }

    class OptmizeDeque
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        internal void Enque(int num)
        {
            while(stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());

            }
            stack1.Push(num);
            while(stack2.Count >0)
            {
                stack1.Push(stack2.Pop());
            }
        }

        internal int Dequeue()
        {
            return stack1.Pop();
        }
    }
}
