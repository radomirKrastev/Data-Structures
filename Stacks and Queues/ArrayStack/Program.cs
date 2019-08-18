
using System;

public class ArrayStack<T>
{
    private T[] elements;
    public int Count { get; private set; }
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            Grow();
        }
        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = elements[this.Count];
        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        Array.Copy(this.elements, arr, this.Count);
        return arr;
    }

    private void Grow()
    {
        var newArray = new T[this.elements.Length * 2];
        Array.Copy(this.elements, newArray, this.Count);
        this.elements = newArray;
    }
}

public class Launcher
{
    public static void Main()
    {
        ArrayStack<int> arr = new ArrayStack<int>();
        arr.Push(1);
        arr.Push(3);
        arr.Push(2);
        System.Console.WriteLine(string.Join(" ", arr.ToArray()));
    }
}