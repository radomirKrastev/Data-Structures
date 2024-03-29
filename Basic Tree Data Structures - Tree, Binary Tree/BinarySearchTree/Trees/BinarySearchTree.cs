﻿using System;
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

    //public int Count()
    //{
    //    List<int> counter = new List<int>();
    //    Count(this.root, counter);        
    //    return counter.Count;
    //}

    //private void Count(Node root, List<int> counter)
    //{
    //    if (root == null)
    //    {
    //        return;
    //    }

    //    Count(root.Left, counter);
    //    Count(root.Right, counter);
    //    counter.Add(1);
    //    return;
    //}

    public void DeleteMax()
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        Node parent = null;
        Node max = this.root;

        while (max.Right != null)
        {
            parent = max;
            max = max.Right;
        }

        if (parent == null)
        {
            this.root = max.Left;
        }
        else
        {
            parent.Right = max.Left;
        }
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node parent = null;
        Node min = this.root;

        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent == null)
        {
            this.root = min.Right;
        }
        else
        {
            parent.Left = min.Right;
        }
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
        Queue<T> queue = new Queue<T>();
        Range(this.root, queue, startRange, endRange);
        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        var lowerRange = startRange.CompareTo(node.Value);
        var higherRange = endRange.CompareTo(node.Value);

        if (lowerRange < 0)
        {
            Range(node.Left, queue, startRange, endRange);
        }

        if (lowerRange <= 0 && higherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }

        if (higherRange > 0)
        {
            Range(node.Right, queue, startRange, endRange);
        }
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
        Console.WriteLine();
        //BST.EachInOrder(Console.WriteLine);
        //BST.DeleteMax();
        //BST.EachInOrder(Console.WriteLine);
        //search.EachInOrder(Console.WriteLine);
    }
}
