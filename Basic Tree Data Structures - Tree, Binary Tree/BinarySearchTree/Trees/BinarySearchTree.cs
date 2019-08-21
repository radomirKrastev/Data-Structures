using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;
    private Node current;

    public BinarySearchTree()
    {

    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;
        
        while (current != null)
        {
            var compare = value.CompareTo(current.Value);

            if (compare < 0)
            {
                parent = current;
                current = current.Left;
            }

            else if (compare > 0)
            {
                parent = current;
                current = current.Right;
            }

            else
            {
                break;
            }
        }

        Node newNode = new Node(value);

        if (value.CompareTo(parent.Value) < 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;
        while (current != null)
        {
            var compare = value.CompareTo(current.Value);

            if (compare < 0)
            {
                current = current.Left;
            }

            else if (compare > 0)
            {
                current = current.Right;
            }

            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;
        while (current != null)
        {
            if (item.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else if (item.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return null;
    }    

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrder(this.root, action);
    }

    private void EachInOrder(Node root, Action<T> action)
    {
        if (root == null)
        {
            return;
        }

        this.EachInOrder(root.Left, action);
        action(root.Value);
        this.EachInOrder(root.Right, action);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        var BST = new BinarySearchTree<int>();
        BST.Insert(6);
        BST.Insert(7);
        BST.Insert(4);
        BST.Insert(5);
        BST.Insert(3);
        Console.WriteLine();
        BST.EachInOrder(Console.WriteLine);
        BinarySearchTree<int> search = BST.Search(4);
        search.EachInOrder(Console.WriteLine);
    }
}
