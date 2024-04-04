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
    }
}