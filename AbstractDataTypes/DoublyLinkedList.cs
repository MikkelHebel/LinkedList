using AbstractDataTypes;
using System;
using System.Text;

namespace ADT
{
    public class DoublyLinkedList : ILinkedList
    {
        private class Node
        {
            public object Data { get; set; }
            public Node? Next { get; set; }
            public Node? Prev { get; set; }

            public Node(object data, DoublyLinkedList list)
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

        public object First
        {
            get { return head?.Data; }
        }

        public object Last
        {
            get { return count > 0 ? ItemAt(count - 1) : null; }
        }

        public void InsertAt(int index, object o)
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
                head.Prev = newHead;
                head = newHead;
            }
            else if (index == count) // insert at end
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                Node newNode = new Node(o, this);
                newNode.Prev = current;
                current.Next = newNode;
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

                newNode.Prev = previous;
                current.Prev = newNode;
            }
            count++;
        }

        public void Insert(object o)
        {
            Node newHead = new(o, this);
            newHead.Next = head;
            head = newHead;
            count++;
        }

        public void Append(object o)
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
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            
            count--;
        }

        public object? ItemAt(int index)
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