using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            ll.AddHead(2);
            ll.AddHead(3);
            ll.AddTail(8);
            ll.AddTail(9);
            ll.print();
            Console.WriteLine();
            //Console.WriteLine("Revrese order.....");
            //ll.Reverse();
            //ll.print();
            bool isAvailable = ll.isPresent(9);
            Console.WriteLine(isAvailable);
            int pos = ll.GetIndex(11);
            Console.WriteLine(pos);
            ll.AddatIndex(10, 2);
            ll.print();
            //ll.DeleteNode(10);
            //ll.DeleteByIndex(1);
            ll.AddAfter(0, 2);
            Console.WriteLine();
            ll.print();
            //ll.AddBefore(20, 2);
            //Console.WriteLine();
            //ll.print();

            LinkedList first = new LinkedList();
            first.AddHead(10);
            first.AddHead(20);
            first.AddHead(30);

            LinkedList second = new LinkedList();
            second.AddHead(40);
            second.AddHead(50);
            second.AddHead(60);
            ll.MergeLinkedList(first, second);
            first.print();
            Console.WriteLine();
            LinkedList newList =  ll.MoveLeftAndRight(8);
            newList.print();
            
            //ll.DeletekthNode()
            Console.Read();
        }
    }



    public class LinkedList
    {
        private Node head;
        private int count = 0;
        public class Node
        {
            internal int value;
            internal Node next;
            internal int count = 0;

            public Node(int v, Node n)
            {
                value = v;
                next = n;
            }
            public Node(int v)
            {
                value = v;
                next = null;
            }


        }

        public void AddHead(int startVal)
        {
            head = new Node(startVal, head);
            count++;
        }

        public void AddTail(int endVal)
        {
            Node newNode = new Node(endVal, null);
            Node curr = head;
            if (head == null)
            {
                head = newNode;
            }

            while (curr.next != null)
                curr = curr.next;

            curr.next = newNode;
            count++;
        }

        public void print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write("|" + temp.value + "| -->");
                temp = temp.next;
            }
        }

        public bool isPresent(int searchVal)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.value == searchVal)
                { return true; }
                temp = temp.next;
            }
            return false;
        }

        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;

            }
            head = prev;
        }


        public int GetIndex(int givenVal)
        {
            Node temp = head;
            int pos = 0;
            while (temp != null)
            {

                if (temp.value == givenVal)
                {
                    return pos;
                }
                temp = temp.next;
                pos++;
            }
            return -1;

        }

        public void AddatIndex(int val, int givenVal)
        {
            Node temp = head;
            int existingPos = GetIndex(givenVal);
            Node newNode = new Node(val, null);
            int pos = 0;
            while (temp != null)
            {


                if (existingPos == pos)
                {
                    newNode.next = temp.next;
                    temp.next = newNode;
                }
                //Console.WriteLine("|" + temp.value + "|");
                temp = temp.next;
                pos++;
            }

           ;
        }

        public void DeleteNode(int val)
        {
            Node prev = null;
            Node current = head;


            while (current != null)
            {
                if (current.value == val)
                {
                    if (current == head)
                    {
                        head = head.next;
                        current = head;
                    }
                    else
                    {
                        prev.next = current.next;
                        current = current.next;
                    }

                }
                else
                {
                    prev = current;
                    current = current.next;
                }
            }



        }


        public void DeleteByIndex(int index)
        {
            Node prev = null;
            Node current = head;
            int currentPos = 0;

            while (current != null)
            {
                if (index == 0)
                {
                    head = head.next;
                    current = head;
                }
                else if (currentPos == index)
                {

                    prev.next = current.next;

                }
                prev = current;
                currentPos++;
                current = current.next;
            }
        }


        public void AddAfter(int first, int given)
        {
            Node temp = head;
            Node firstNode = new Node(first, null);


            while (temp != null)
            {
                if (temp.value == given)
                {
                    firstNode.next = temp.next;
                    temp.next = firstNode;
                }

                temp = temp.next;


            }

        }

        public void AddBefore(int first, int given)
        {
            Node temp = head;
            Node firstNode = new Node(first, null);


            while (temp != null)
            {
                if (temp.value == given)
                {
                    firstNode.next = temp;
                    temp = firstNode;
                }

                temp = temp.next;


            }

        }
        //define two pointers first one jump by one position
        //second will jump two positions at a time
        //stop jumping when they both come to same node
        //now reset first to head
        //move both by one until they again meet.
        //position of first pointer is answer


        public Node FindLoop(Node head)
        {
            Node first = head.next;
            Node second = head.next.next;
            while(first != second)
            {
                first = first.next;
                second = second.next.next;
            }

            first = head;
            while(first != second)
            {
                first = first.next;
                second = second.next;
            }

            return first;
        }


        public LinkedList MoveLeftAndRight(int val)
        {
            Node temp = head;
            LinkedList left = new LinkedList();
            LinkedList right = new LinkedList();

            while (temp != null)
            {
                if(temp.value < val)
                {
                    left.AddHead(temp.value);
                }
                else
                {
                    if (right.count == 0)
                        right.AddHead(temp.value);
                    else
                    right.AddTail(temp.value);
                }
                temp = temp.next;

            }

            MergeLinkedList(left, right);

            return left;
   

        }


        public  LinkedList MergeLinkedList(LinkedList first,LinkedList second)
        {
            Node temp = second.head;

            while(temp != null)
            {

                first.AddTail(temp.value);
                temp = temp.next;
            }

            return first;
        }

        // you have access to given node only
        //so go to next node
        //copy value of next node to given
        //copy link of next node to given node
        public Boolean DeletekthNode(Node n)
        {
            if (n == null || n.next == null)
                return false;
            Node temp = n.next;
            n.value = temp.value;
            n.next = temp.next;
            return true;

        }
        //define two pointers 
        //both initialize to head
        //jump second by k position
        //now move both pointer by one position
        //when second pointer reach at end first pointer will be kth node from last;
        public int GetKthFromLast(Node head,int k)
        {
            Node temp = head;
            while(temp != null && k >0)
            {
                temp = temp.next;
                k = k - 1;
            }

            while(temp != null)
            {
                head = head.next;
                temp = temp.next;
            }

            return head.value;
        }
    }





}
    

