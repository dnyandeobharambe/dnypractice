using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayStack arrStk = new ArrayStack();
            //arrStk.Push(5);
            //arrStk.Push(10);
            //arrStk.Push(15);
            //arrStk.Push(20);
            //arrStk.Push(25);
            //arrStk.Push(30);
            //arrStk.Push(35);
            //arrStk.Print();
            //arrStk.Pop();
            //arrStk.Print();
            //arrStk.Pop();
            //arrStk.Print();

            //Dictionary<string, int> minMaxDict = new Dictionary<string, int>();
            //arrStk.MinMaxStack(5, minMaxDict);
            //arrStk.MinMaxStack(7, minMaxDict);
            //arrStk.MinMaxStack(0, minMaxDict);
            //arrStk.MinMaxStack(11, minMaxDict);
            //arrStk.MinMaxStack(9, minMaxDict);
            //arrStk.MinMaxStack(-5, minMaxDict);
            //List<int> arr =  arrStk.MinMaxStack(2, minMaxDict);
            //arrStk.Peek();


            //foreach(int x in arr)
            //{
            //    Console.WriteLine(x);
            //    Console.WriteLine();
            //}

            Boolean isBrack = arrStk.CheckBrackets("([{}]{)");
            Console.WriteLine(isBrack);

            ExtendedStack es = new ExtendedStack();
            es.PushToExtendedStack(10);
            es.PushToExtendedStack(5);
            es.PushToExtendedStack(7);
            es.PushToExtendedStack(25);
            es.PushToExtendedStack(3);
            es.PushToExtendedStack(12);
            Console.WriteLine(es.GetMin());

            Console.Read();

            

        }
    }

    public class ArrayStack
    {
        static readonly int MAX = 1000;
        int top = -1;
     
        int[] stack = new int[MAX];
        char[] charStack = new char[MAX];

        internal void Push(int data)
        {
            if(top > MAX)
            {
                Console.WriteLine(" Stack overflow ");
            }
            else
            {
                top++;
                stack[top] = data;
            }
        }

        internal int Pop()
        {
            int topVal = -1;
            if (top < 0)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                 topVal = stack[top];
                top--;
            }
            return topVal;
        }

       


        internal void PushChar(char data)
        {
            if (top > MAX)
            {
                Console.WriteLine(" Stack overflow ");
            }
            else
            {
                top++;
                charStack[top] = data;
            }
        }

        internal char PopChar()
        {
            char topVal = ' ';
            if (top < 0)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                topVal = charStack[top];
                top--;
            }
            return topVal;
        }

        internal int Count()
        {
            return top;
        }

        internal void Peek()
        {
            if(top < 0)
            {
                Console.WriteLine("Stack is empty");

            }
            else
            {
                Console.WriteLine("Top most element is:" + "  " + stack[top]);
            }
        }

        internal void Print()
        {
            for(int i = top;i > 0; i--)
            {
                Console.WriteLine("Stack Elements:" + " - " + stack[i]);
            }

            Console.Read();
        }

        internal List<int> MinMaxStack(int val, Dictionary<string, int> minMaxDict)
        {
           

            if (top < 0)
            {
                Push(val);
                minMaxDict.Add("min", val);
                minMaxDict.Add("max", val);

            }
            else if (minMaxDict["max"] < val)
            {
                minMaxDict["max"] = val;
            }
            else if (minMaxDict["min"] > val)
            {
                minMaxDict["min"] = val;
            }

            return new List<int> { minMaxDict["min"], minMaxDict["max"] };
        }




        internal Boolean CheckBrackets(string expr)
        {
            foreach(char ch in expr.ToCharArray())
            {
                if(ch == '(' || ch == '[' || ch == '{')
                {
                    PushChar(ch);
                }
                //else if (ch == '[')
                //{
                //    PushChar(ch);
                //}
                //else if (ch == '{')
                //{
                //    PushChar(ch);
                //}
                else if(ch == ')')
                {
                    if(PopChar() != '(')
                    {
                        return false;
                    }
                }
                else if (ch == '}')
                {
                    if (PopChar() != '{')
                    {
                        return false;
                    }
                }
                else if (ch == ']')
                {
                    if (PopChar() != '[')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
        



    }

    public class ExtendedStack
    {
        Stack<int> sourceStack = new Stack<int>();
        Stack<int> resultStack = new Stack<int>();

        internal void PushToExtendedStack(int num)
        {
            
            if (sourceStack.Count == 0 || num <= resultStack.Peek())
            {
                
                resultStack.Push(num);
            }
            sourceStack.Push(num);

        }

        internal int PopToExtendedStack()
        {
            if(sourceStack.Peek() == resultStack.Peek())
            {
                
                resultStack.Pop();
            }
            return sourceStack.Pop();
        }

        internal int GetMin()
        {
            return resultStack.Peek();
        }

        
    }

    public class OptimizePush
    {
        Queue<int> q1 = new Queue<int>();
        Queue<int> q2 = new Queue<int>();

        internal void Push(int data)
        {
            q1.Enqueue(data);
        }

        internal int Pop()
        {
            while(q1.Count > 1)
            {
                q2.Enqueue(q1.Dequeue());
            }
            int val = q1.Dequeue();
            Swap();
            return val;
        }

        private void Swap()
        {
            Queue<int> q3 = q1;
            q1 = q2;
            q2 = q3;
        }
    }

    public class OptimizePop
    {
        Queue<int> q1 = new Queue<int>();
        Queue<int> q2 = new Queue<int>();

        internal void Push(int data)
        {
            if(q1.Count == 0)
            {
                q1.Enqueue(data);
            }
            else
            {
                q2.Enqueue(data);
                while(q1.Count >0)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                Swap();
            }
        }
        internal int Pop()
        {
            return q1.Dequeue();
        }
        private void Swap()
        {
            Queue<int> q3 = q1;
            q1 = q2;
            q2 = q3;
        }


    }


}
