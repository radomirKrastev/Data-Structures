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
            Console.WriteLine(string.Join(" ", tree.FindLeafs()));
            Console.WriteLine(string.Join(" ", tree.FindMiddle()));
            Console.WriteLine(string.Join(" ", tree.LongestPath()));
            Console.WriteLine(tree.DeepestNode());
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

            public T DeepestNode()
            {
                var collection = LongestPath();
                var deepestNode = collection.Last();
                return deepestNode;
            }

            public IEnumerable<T> LongestPath()
            {
                var longestPath = new List<T>();
                var deepestNodeCount = int.MinValue;
                var leafs = QueueHelper("leaf");

                foreach (var leaf in leafs)
                {   
                    var counter = 0;
                    Queue<Node> queue = new Queue<Node>();
                    var current = leaf;
                    var collection = new List<T>() { current.Value };
                    queue.Enqueue(current);
                    while (queue.Count > 0 && current.Parent!=null)
                    {
                        counter++;
                        current = queue.Dequeue().Parent;
                        collection.Add(current.Value);
                        queue.Enqueue(current);
                    }

                    if (counter > deepestNodeCount)
                    {
                        longestPath = collection;
                        deepestNodeCount = counter;
                    }
                }

                longestPath.Reverse();
                return longestPath;
            }

            private IEnumerable<Node> QueueHelper(string condition)
            {
                var collection = new List<Node>();

                Queue<Node> queue = new Queue<Node>();
                Node current = null;
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    current = queue.Dequeue();
                    if (condition == "middle")
                    {
                        if (current.Children.Count > 0 && current.Parent != null)
                        {
                            collection.Add(current);
                        }
                    }
                    else if(condition == "leaf")
                    {
                        if (current.Children.Count == 0)
                        {
                            collection.Add(current);
                        }
                    }

                    foreach (var child in current.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

                return collection;
            }

            public IEnumerable<T> FindMiddle()
            {
                string condition = "middle";
                var list = QueueHelper(condition).Select(x=>x.Value);
                return list.OrderBy(x=>x);
            }

            public IEnumerable<T> FindLeafs()
            {
                string condition = "leaf";
                var list = QueueHelper(condition).Select(x=>x.Value);
                return list;//.OrderBy(x => x);
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
