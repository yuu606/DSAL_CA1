using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    [Serializable]
    public class Node<T>
    {
        public T? Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }
        public Node(T _data)
        { 
            this.Data = _data;
            this.Next = null;
            this.Prev = null;
        }
    }

    public class DoubleLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        private int _count { get; set; }
        public int Count { get => _count; }

        public void InsertAtEnd(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }
    }
}
