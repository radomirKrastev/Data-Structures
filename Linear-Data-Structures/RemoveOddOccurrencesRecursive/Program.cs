namespace RemoveOddOccurrencesRecursive
{
    using System;
    public class Program
    {
        public static int lastEven = 0;

        public static void Main()
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToList();
            var element = data[lastEven];

            RemoveOdd(data, element, 0, 0);

            Console.WriteLine(string.Join(" ", data));
        }

        public static void RemoveOdd(List<int> data, int element, int index, int count)
        {
            if (index == data.Count)
            {
                if (count % 2 != 0)
                {
                    if (data.IndexOf(element) == 0)
                    {
                        lastEven = 0;
                    }

                    else
                    {
                        lastEven = (data.IndexOf(element) - 1) + 1;
                    }

                    while (data.Contains(element))
                    {
                        data.Remove(element);
                    }

                    if (data.Count == 0)
                    {
                        return;
                    }

                    RemoveOdd(data, data[lastEven], 0, 0);
                }

                else
                {
                    lastEven += 1;

                    if (lastEven >= data.Count)
                    {
                        return;
                    }

                    RemoveOdd(data, data[lastEven], 0, 0);
                }
            }

            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    index++;
                    if (data[i] == element)
                    {
                        count++;
                    }
                }

                RemoveOdd(data, element, index, count);
            }
        }
    }
}
