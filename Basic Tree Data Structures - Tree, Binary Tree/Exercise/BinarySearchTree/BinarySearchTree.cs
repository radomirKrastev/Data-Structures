﻿using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }

    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node current = this.root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (parent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
        throw new NotImplementedException();
    }

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

    public int Count()
    {
        List<int> counter = new List<int>();
        Count(this.root, counter);
        return counter.Count;
    }

    private void Count(Node root, List<int> counter)
    {
        if (root == null)
        {
            return;
        }

        Count(root.Left, counter);
        Count(root.Right, counter);
        counter.Add(1);
        return;
    }

    public int Rank(T element)
    {
        var list = new List<T>();
        Rank(this.root, element, list);
        return list.Count;
    }

    private void Rank (Node root, T element, List<T> list)
    {
        if (root == null)
        {
            return;
        }

        var compare = element.CompareTo(root.Value);
        if (compare <= 0)
        {
            Rank(root.Left, element, list);
        }
        else if (compare > 0)
        {            
            Rank(root.Left, element,list);
            Rank(root.Right, element, list);
            list.Add(root.Value);
        }

        return;
    }

    public T Select(int rank)
    {
        var list =new List<T>();
        Select(this.root, list, rank);
        return list.First();
    }

    private void Select(Node root, List<T> list, int rank)
    {
        if (root == null)
        {
            return;
        }

        var counter = new List<T>();
        Rank(this.root, root.Value, counter);
        if (counter.Count == rank)
        {
            list.Add(root.Value);
            return;
        }
        else
        {
            Select(root.Left, list, rank);
            Select(root.Right, list, rank);
        }
    }

    public T Ceiling(T element)
    {
        throw new NotImplementedException();
    }

    public T Floor(T element)
    {
        throw new NotImplementedException();
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(1);
        bst.Insert(4);
        bst.Insert(8);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);
        int rk = bst.Rank(45);
        bst.EachInOrder(Console.WriteLine);
        Console.WriteLine();
        int rank = bst.Select(9);
        Console.WriteLine(rank);
        Console.WriteLine(rk);
    }
}