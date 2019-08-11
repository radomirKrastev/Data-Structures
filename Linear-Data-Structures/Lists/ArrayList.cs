using System;

public class ArrayList<T>
{
    private T[] data;

    public ArrayList()
    {
        this.data = new T[2];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if(index>=0 && index < data.Length)
            {
                return this.data[index];
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }            
        }

        set
        {
            if (index >= 0 && index < data.Length)
            {
                this.data[index] = value;
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }            
        }
    }

    public void Add(T item)
    {
        if (Count== this.data.Length)
        {
            this.Resize();
        }

        this.data[this.Count++] = item;
    }

    private void Resize()
    {
        T[] resizedArray = new T[Count*2];
        Array.Copy(this.data, resizedArray, Count);
        this.data = resizedArray;
    }

    public T RemoveAt(int index)
    {
        if(index<0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.data[index];

        for (int i = index; i < Count; i++)
        {
            this.data[i] = data[i + 1];
        }

        Count--;
        return element;
    }

    public void PrintArrayList()
    {
        Console.WriteLine(string.Join(" ", this.data));
    }
}
