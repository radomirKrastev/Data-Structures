using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node (T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node NextNode { get; set; }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var newHead = new Node(item);
        if (this.Count == 0)
        {
            this.Head = this.Tail = newHead;
        }
        else
        {
            newHead.NextNode = this.Head;
            this.Head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        var newTail = new Node(item);
        if (this.Count == 0)
        {
            this.Head = this.Tail = newTail;
        }
        else
        {
            this.Tail.NextNode = newTail;
            this.Tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var firstElement = this.Head.Value;
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            this.Head = this.Head.NextNode;
        }

        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var lastElement = this.Tail.Value;
        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            var currentNode = this.Head;
            var position = 0;
            while (position != this.Count - 2)
            {
                currentNode = currentNode.NextNode;
                position++;
            }

            this.Tail = currentNode;
        }

        Count--;
        return lastElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
