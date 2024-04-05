using AbstractDataTypes;
using System;

namespace ADT
{
    public class LinkedList : ILinkedList
    {
        private class Node
        {
            public object Data { get; set; }
            public Node? Next { get; set; }

            public Node(object data, LinkedList list)
            {
                Data = data;
                count++;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node head { get; set; }
        private static int count;

        public int Count {
            get { return count; }
        }

        public void InsertAt(int index, object o) {
            Node current = head;

            if (head == null) {
                head = new Node(o, this);
                return;
            }
            if (index > count || index < 0) {
                throw new IndexOutOfRangeException();
            }

            if (index == 0) { //move head
                Node newHead = new Node(o, this);
                newHead.Next = head;
                head = newHead;
            }
            else if (index == count) // insert at end
            {
                while (current.Next != null) {
                    current = current.Next;
                }
                current.Next = new Node(o, this);
            }
            else // insert at position
            {
                int currentIndex = 0;

                while (current != null && currentIndex <= index) {
                    if (currentIndex == index) {
                        Node newNode = new Node(o, this);
                        newNode.Next = current.Next;
                        current.Next = newNode;
                    }
                    currentIndex++;
                    current = current.Next;
                }
            }
        }

        public void DeleteAt(int index) {
            if (index == 0) {
                head = head.Next;
                count--;
                return;
            }
            if (index > Count || index < 0) {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            int currentIndex = 0;
            
            while (current != null) {
                if (currentIndex == index -1) {
                    current.Next = current.Next.Next;
                    count--;
                    return;
                }
                currentIndex++;
                current = current.Next;
            }
        }

        public object? ItemAt(int index) {
            Node current = head;

            if (index == 0) {
                return head.Data;
            }
            if (index > count || index < 0) {
                throw new IndexOutOfRangeException();
            }
            
            int currentIndex = 0;
            while (current != null && currentIndex <= index) {
                if (currentIndex == index) {
                    return current.Data;
                }
                currentIndex++;
                current = current.Next;
            }
            return null;
        }

        public override string ToString()
        {
            string contents = "LinkedList:\n";

            Node current = head;
            while (current != null)
            {
                contents += current.Data + "\n";
                current = current.Next;
            }

            return contents;
        }
    }
}