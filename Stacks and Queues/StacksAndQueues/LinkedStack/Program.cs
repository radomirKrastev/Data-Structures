namespace LinkedStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class LinkedStack<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        private StackNode top;

        public void Push(T element)
        {
            this.top = new StackNode(element, this.top);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            StackNode result = this.top;
            this.top = this.top.Next;
            this.Count--;
            return result.Value;            
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.top.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            StackNode current = this.top;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class StackNode
        {
            public T Value { get; set; }
            public StackNode Next { get; set; }

            public StackNode (T value, StackNode next)
            {
                this.Value = value;
                this.Next = next;
            }
        }
    }
}
