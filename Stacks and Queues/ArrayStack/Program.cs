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
            throw new InvalidOperationException("Stack is empty!");
        }

        this.Count--;
        return this.elements[Count];
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        var arrIndex = 0;
        var elementsIndex = this.Count - 1;

        for (int i = 0; i < this.Count; i++)
        {
            arr[arrIndex++] = elements[elementsIndex--];
        }

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
        arr.Push(7);
        arr.Push(8);
        arr.Push(9);
        Console.WriteLine(arr.Count);
        var item = arr.Pop();
        Console.WriteLine(item);
        var item1 = arr.Pop();
        Console.WriteLine(item);
        var item2 = arr.Pop();
        Console.WriteLine(string.Join(" ", arr.ToArray()));
    }
}

