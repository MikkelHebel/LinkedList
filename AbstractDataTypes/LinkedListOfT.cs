using AbstractDataTypes;
using System;
using System.Text;

namespace ADT
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node? Next { get; set; }

            public Node(T data, LinkedList<T> list)
            {
                Data = data;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node head { get; set; }
        private int count;

        public int Count
        {
            get { return count; }
        }

        public T First
        {
            get { return head != null ? head.Data : default(T); }
        }

        public T Last
        {
            get { return count > 0 ? ItemAt(count - 1) : default; }
        }

        public void InsertAt(int index, T o)
        {
            Node current = head;
            Node previous = null;

            if (head == null)
            {
                head = new Node(o, this);
                count++;
                return;
            }
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            { //move head
                Node newHead = new Node(o, this);
                newHead.Next = head;
                head = newHead;
            }
            else if (index == count) // insert at end
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(o, this);
            }
            else // insert at position
            {
                int currentIndex = 0;

                while (current != null && currentIndex < index)
                {
                    previous = current;
                    current = current.Next;
                    currentIndex++;
                }
                Node newNode = new Node(o, this);
                newNode.Next = current;
                previous.Next = newNode;
            }
            count++;
        }

        public void Insert(T o)
        {
            Node newHead = new(o, this);
            newHead.Next = head;
            head = newHead;
            count++;
        }

        public void Append(T o)
        {
            if (head == null)
            {
                head = new Node(o, this);
                count++;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(o, this);
                count++;
            }
        }

        public void DeleteAt(int index)
        {
            if (index == 0)
            {
                head = head.Next;
                count--;
                return;
            }
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index - 1)
                {
                    if (current.Next != null)
                    {
                        current.Next = current.Next.Next;
                    }
                    else
                    {
                        current.Next = null;
                    }
                    count--;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public T? ItemAt(int index)
        {
            Node current = head;

            if (index == 0)
            {
                return head.Data;
            }
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            int currentIndex = 0;
            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            return current.Data;
        }

        public override string ToString()
        {
            StringBuilder contents = new StringBuilder();

            Node current = head;
            while (current != null)
            {
                contents.Append(current.Data.ToString());
                current = current.Next;
                if (current != null)
                {
                    contents.Append("\n");
                }
            }

            return contents.ToString();
        }
    }
}