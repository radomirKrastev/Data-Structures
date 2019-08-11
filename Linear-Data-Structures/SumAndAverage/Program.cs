namespace SumAndAverage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var list = new List<int>();
            list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = list.Sum();
            var average = list.Average();
            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}
