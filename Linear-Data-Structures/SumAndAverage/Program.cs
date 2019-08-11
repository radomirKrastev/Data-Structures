namespace SumAndAverage
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = list.Sum();
            var average = list.Average();
            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}
