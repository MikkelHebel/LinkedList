using System;

namespace MyLinkedList
{
    public class Node
    {
        public object data { get; set; }
        public Node? next { get; set; }

        public Node(object data, LinkedList list)
        {
            this.data = data;
            list.IncrementCount();
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}