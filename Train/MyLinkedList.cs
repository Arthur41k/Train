using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class MyLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;

        public void Add(T value)
        {
            Node node = new Node(value);

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
        }

        public bool Remove(T value)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;

                if (head != null)
                {
                    head.Prev = null;
                }
                else
                {
                    tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (tail != null)
            {
                tail = tail.Prev;

                if (tail != null)
                {
                    tail.Next = null;
                }
                else
                {
                    head = null;
                }
            }
        }

        public void AddFirst(T value)
        {
            Node node = new Node(value);

            if (head != null)
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            else
            {
                head = node;
                tail = node;
            }
        }

        public void AddLast(T value)
        {
            Add(value);
        }

        public void AddAfter(T value, T newValue)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    Node newNode = new Node(newValue);
                    newNode.Next = current.Next;
                    newNode.Prev = current;

                    if (current.Next != null)
                    {
                        current.Next.Prev = newNode;
                    }
                    else
                    {
                        tail = newNode;
                    }

                    current.Next = newNode;
                    return;
                }

                current = current.Next;
            }
        }

    }
}
