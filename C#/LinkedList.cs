using System;

namespace MyLinkedList
{
    public class LinkedList
    {
        public Node head { get; set; }
        public static int count { get; set; }

        public void IncrementCount()
        {
            count++;
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
                newHead.next = head;
                head = newHead;
            }
            else if (index == count) // insert at end
            {
                while (current.next != null) {
                    current = current.next;
                }
                current.next = new Node(o, this);
            }
            else // insert at position
            {
                int currentIndex = 0;

                while (current != null && currentIndex <= index) {
                    if (currentIndex == index) {
                        Node newNode = new Node(o, this);
                        newNode.next = current.next;
                        current.next = newNode;
                    }
                    currentIndex++;
                    current = current.next;
                }
            }
        }

        public void DeleteAt(int index) {
            if (index == 0) {
                head = head.next;
                count--;
                return;
            }
            if (index > count || index < 0) {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            int currentIndex = 0;
            
            while (current != null) {
                if (currentIndex == index -1) {
                    current.next = current.next.next;
                    return;
                }
                currentIndex++;
                current = current.next;
            }
        }

        public object? ItemAt(int index) {
            Node current = head;

            if (index == 0) {
                return head.data;
            }
            if (index > count || index < 0) {
                throw new IndexOutOfRangeException();
            }
            
            int currentIndex = 0;
            while (current != null && currentIndex <= index) {
                if (currentIndex == index) {
                    return current.data;
                }
                currentIndex++;
                current = current.next;
            }
            return null;
        }

        public override string ToString()
        {
            string contents = "LinkedList:\n";

            Node current = head;
            while (current != null)
            {
                contents += current.data + "\n";
                current = current.next;
            }

            return contents;
        }
    }
}