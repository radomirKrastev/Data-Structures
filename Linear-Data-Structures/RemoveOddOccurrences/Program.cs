namespace RemoveOddOccurrences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbersOccurences = new Dictionary<int, int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (!numbersOccurences.ContainsKey(data[i]))
                {
                    numbersOccurences[data[i]] = 0;
                }

                numbersOccurences[data[i]]++;
            }

            var numbersLeft = new List<int>();

            foreach (var number in numbersOccurences)
            {
                if (number.Value % 2 == 0)
                {
                    for (int i = 0; i < number.Value; i++)
                    {
                        numbersLeft.Add(number.Key);
                    }                    
                }
            }

            Console.WriteLine(string.Join(" ", numbersLeft));
        }
    }
}
