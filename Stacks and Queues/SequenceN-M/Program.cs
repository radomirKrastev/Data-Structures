namespace SequenceN_M
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var startToEnd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var start = startToEnd[0];
            var end = startToEnd[1];

            Queue<Item> items = new Queue<Item>();
            items.Enqueue(new Item(start));

            while (items.Count != 0)
            {
                var item = items.Dequeue();
                if (item.Value < end)
                {
                    items.Enqueue(new Item(item.Value + 1) { Previous = item });
                    items.Enqueue(new Item(item.Value + 2) { Previous = item });
                    items.Enqueue(new Item(item.Value * 2) { Previous = item });
                }

                if (item.Value == end)
                {
                    PrintSolution(item);
                    break;
                }
            }
        }

        public static void PrintSolution(Item item)
        {
            var shortestSequence = new List<int>();
            while (item != null)
            {
                shortestSequence.Add(item.Value);
                item = item.Previous;
            }

            shortestSequence.Reverse();
            Console.WriteLine(string.Join(" -> ", shortestSequence));
        }

        public class Item
        {
            public int Value { get; set; }
            public Item Previous { get; set; }

            public Item(int value)
            {
                this.Value = value;
            }
        }
    }
}
