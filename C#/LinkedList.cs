using System;

namespace MyLinkedList
{
    public class LinkedListClass
    {
        public Node head { get; set; }
        public int count { get; set; }

        public void InsertAt(object o, int index=0) {
            Node current = head;

            if (head == null) {
                head = new Node(o);
            }
            if (index > count || index < 0) {
                throw new IndexOutOfRangeException();
            }

            if (index == 0) { //move head
                Node newHead = new Node(o);
                newHead.next = head;
                head = newHead;
            }
            else if (index == count) // insert at end
            {
                while (current.next != null) {
                    current = current.next;
                }
                current.next = new Node(o);
            }
            else // insert at position
            {
                int currentIndex = 0;

                while (current != null && currentIndex <= index) {
                    if (currentIndex == index) {
                        Node newNode = new Node(o);
                        newNode.next = current.next;
                        current.next = newNode;
                    }
                    currentIndex++;
                    current = current.next;
                }
            }
        }

        public void DeleteAt(int index) {
            Node current = head;

            if (index == 0) {
                head = head.next;
            }

            int currentIndex = 0;
            while (current != null && currentIndex <= index - 1) {
                if (currentIndex == index) {
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