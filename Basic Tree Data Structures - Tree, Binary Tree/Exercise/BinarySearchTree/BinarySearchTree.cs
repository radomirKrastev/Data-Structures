using System;
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
            throw new InvalidOperationException();
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
        if (this.root == null || Contains(element) == false)
        {
            throw new InvalidOperationException();
        }

        if(this.root.Left==null && this.root.Right == null)
        {
            this.root = null;
            return;
        }

        Node elementNode = FindElement(element);

        if (elementNode.Right != null && elementNode.Left == null)
        {
            elementNode = elementNode.Right;

        }
        else if (elementNode.Left != null && elementNode.Right == null)
        {
            elementNode = elementNode.Left;
        }
        else if(elementNode.Left==null && elementNode.Right == null)
        {
            elementNode = null;
        }
        else
        {
            List<Node> rightSubtreeList = new List<Node>();
            Count(elementNode.Right, rightSubtreeList);
            Node floor = elementNode.Right;

            foreach (var node in rightSubtreeList)
            {
                if (floor.Value.CompareTo(node.Value) > 0)
                {
                    floor = node;
                }
            }

            Node rightSubtree = null;
            rightSubtree = CopySubtree(elementNode.Right, rightSubtree, floor);
            Node leftSubtree = null;
            leftSubtree = CopySubtree(elementNode.Left, leftSubtree, null);

            elementNode = floor;
            elementNode.Right = rightSubtree;
            elementNode.Left = leftSubtree;
        }

        Node current = this.root;
        Node parent = null;
        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        if (parent == null)
        {
            this.root = elementNode;
        }
        else
        {
            if (parent.Left == current)
            {
                parent.Left = elementNode;
            }
            else
            {
                parent.Right = elementNode;
            }
        }        
    }

    private Node CopySubtree(Node root, Node copiedTree, Node floor)
    {
        if (root == null)
        {
            return copiedTree;
        }

        if (root != floor)
        {
            copiedTree = Insert(root.Value, copiedTree);
        }

        copiedTree = CopySubtree(root.Left, copiedTree, floor);
        copiedTree = CopySubtree(root.Right, copiedTree, floor);

        return copiedTree;
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
        List<Node> counter = new List<Node>();
        Count(this.root, counter);
        return counter.Count;
    }

    private void Count(Node root, List<Node> counter)
    {
        if (root == null)
        {
            return;
        }

        Count(root.Left, counter);
        Count(root.Right, counter);
        counter.Add(root);
        return;
    }

    public int Rank(T element)
    {
        var list = new List<T>();
        Rank(this.root, element, list);
        return list.Count;
    }

    private void Rank(Node root, T element, List<T> list)
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
            Rank(root.Left, element, list);
            Rank(root.Right, element, list);
            list.Add(root.Value);
        }

        return;
    }

    public T Select(int rank)
    {
        var list = new List<T>();
        Select(this.root, list, rank);
        if (list.Count > 0)
        {
            return list.First();
        }
        else
        {
            throw new InvalidOperationException();
        }
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
        if (this.root == null || Contains(element) == false)
        {
            throw new InvalidOperationException();
        }

        Node elementNode = this.root;
        Node current = this.root;
        while (current.Right != null)
        {
            current = current.Right;
        }

        T value = current.Value;
        var comparer = element.CompareTo(elementNode.Value);

        while (elementNode.Value.CompareTo(element) != 0)
        {
            bool valueCondition = value.CompareTo(elementNode.Value) > 0 && elementNode.Value.CompareTo(element) > 0;

            if (element.CompareTo(elementNode.Value) < 0)
            {
                if (valueCondition)
                {
                    value = elementNode.Value;
                }

                elementNode = elementNode.Left;
            }

            else if (element.CompareTo(elementNode.Value) > 0)
            {
                if (valueCondition)
                {
                    value = elementNode.Value;
                }

                elementNode = elementNode.Right;
            }
        }

        if (elementNode.Right != null)
        {
            var floorNode = elementNode.Right;
            while (floorNode.Left != null)
            {
                floorNode = floorNode.Left;
            }

            return floorNode.Value;
        }

        if (value.CompareTo(element) == 0)
        {
            throw new InvalidOperationException();
        }

        return value;
    }

    public T Floor(T element)
    {
        if (this.root == null || Contains(element) == false)
        {
            throw new InvalidOperationException();
        }

        Node elementNode = this.root;
        Node current = this.root;
        while (current.Left != null)
        {
            current = current.Left;
        }

        T value = current.Value;
        var comparer = element.CompareTo(elementNode.Value);

        while (elementNode.Value.CompareTo(element) != 0)
        {
            bool valueCondition = value.CompareTo(elementNode.Value) < 0 && elementNode.Value.CompareTo(element) < 0;

            if (element.CompareTo(elementNode.Value) < 0)
            {
                if (valueCondition)
                {
                    value = elementNode.Value;
                }

                elementNode = elementNode.Left;
            }

            else if (element.CompareTo(elementNode.Value) > 0)
            {
                if (valueCondition)
                {
                    value = elementNode.Value;
                }

                elementNode = elementNode.Right;
            }
        }

        if (elementNode.Left != null)
        {
            var floorNode = elementNode.Left;
            while (floorNode.Right != null)
            {
                floorNode = floorNode.Right;
            }

            return floorNode.Value;
        }

        if (value.CompareTo(element) == 0)
        {
            throw new InvalidOperationException();
        }

        return value;
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

        //bst.Insert(15);
        //bst.Insert(10);
        //bst.Insert(8);
        //bst.Insert(9);
        //bst.Insert(6);
        //bst.Insert(11);
        //bst.Insert(12);
        //bst.Insert(13);
        //bst.Insert(14);
        //bst.Insert(39);
        //bst.Insert(37);
        //bst.Insert(45);
        //bst.Insert(500);
        //bst.Insert(300);
        //bst.Insert(257);
        //bst.Insert(258);
        //bst.Insert(231);
        //bst.Insert(186);
        //bst.Insert(97);
        //bst.Insert(152);
        //bst.Insert(87);
        //bst.Insert(205);
        //bst.Insert(225);

        bst.Insert(10);
        bst.Insert(5);
        //bst.Insert(3);
        //bst.Insert(1);
        //bst.Insert(4);
        //bst.Insert(8);
        //bst.Insert(9);
        //bst.Insert(37);
        bst.Insert(39);
        //bst.Insert(45);

        //bst.Insert(12);
        //bst.Insert(21);
        //bst.Insert(5);
        //bst.Insert(1);
        //bst.Insert(8);
        //bst.Insert(18);
        Console.WriteLine();
        bst.Delete(5);
        //var select = bst.Select(100);
        //Console.WriteLine(select);
        //int ceiling = bst.Ceiling(8);
        //int ceiling = bst.Ceiling(4);
        //Console.WriteLine(ceiling);
    }
}