using System;

namespace MyLinkedList
{
    public class Node
    {
        public object data { get; set; }
        public Node? next { get; set; }

        public Node(object data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}