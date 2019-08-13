namespace ReversedList
{
    using System;
    public class ReversedList<T>
    {
        private T[] data;

        public ReversedList()
        {
            this.data = new T[2];
        }

        public int Count { get; private set; }

        public int Capacity 
        {
            get
            {
                return this.data.Length;
            }
        }

        public void Add(T item)
        {
            if (Count == this.data.Length)
            {
                this.Resize();
            }

            this.data[Count++] = item;
            T[] helpList = new T[data.Length];
            var previous = data[0];

            for (int i = 1; i < Count; i++)
            {
                helpList[i] = this.data[i - 1];
            }

            helpList[0] = item;
            this.data = helpList;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.data.Length)
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
                if (index >= 0 && index < this.data.Length)
                {
                    this.data[index] = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            Count--;
        }

        private void Resize()
        {
            T[] newReversedList = new T[this.data.Length * 2];
            Array.Copy(this.data, newReversedList, Count);
            this.data = newReversedList;
        }

        public void PrintArrayList()
        {
            Console.WriteLine(string.Join(" ", this.data));
        }
    }
}
