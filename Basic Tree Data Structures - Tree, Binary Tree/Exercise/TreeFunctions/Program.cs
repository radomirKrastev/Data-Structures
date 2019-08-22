using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeFunctions
{
    public class Program
    {
        public static void Main()
        {
            var commands = int.Parse(Console.ReadLine());
            Tree<int> tree = new Tree<int>();

            for (int i = 0; i < commands - 1; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                tree.Insert(edge[1], edge[0]);

                Console.WriteLine();
            }

            tree.Print();
        }

        public class Tree<T> where T : IComparable<T>
        {
            public T rootValue { get; private set; }
            private Node current;
            private Node root { get; set; }
            public int Count { get; set; }

            private class Node
            {
                public Node Parent { get; set; }
                public T Value { get; set; }
                public List<Node> Children { get; set; }
                public Node(T value)
                {
                    this.Value = value;
                    this.Children = new List<Node>();
                    this.Parent = null;
                }
            }

            public void Print(int indent = 0)
            {
                Print(indent, this.root);
            }

            private void Print(int indent, Node root)
            {
                Console.Write(new string(' ', 2 * indent));
                Console.WriteLine(root.Value);
                foreach (var child in root.Children)
                {
                    Print(indent + 1, child);
                }
            }

            public void Insert(T value, T parent)
            {
                var node = Contains(this.root, parent);
                if (node == null)
                {
                    this.rootValue = parent;
                    this.current = new Node(parent);
                    this.root = current;
                    Link(current, value);
                }
                else
                {
                    Link(node, value);
                }
            }

            private Node Contains(Node root, T parent)
            {
                Queue<Node> queue = new Queue<Node>();
                Node current = null;
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    current = queue.Dequeue();
                    if (current == null)
                    {
                        return root;
                    }
                    else if (current.Value.CompareTo(parent) == 0)
                    {
                        return current;
                    }

                    foreach (var child in current.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

                return root;
            }

            private void Link(Node current, T value)
            {
                var child = new Node(value);
                child.Parent = current;
                current.Children.Add(child);
            }
        }
    }
}
