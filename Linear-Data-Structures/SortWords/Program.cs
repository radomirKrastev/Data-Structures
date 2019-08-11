namespace SortWords
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries).ToList();
            var sortedWords = words.OrderBy(x => x);
            Console.WriteLine(string.Join(" ", sortedWords));
        }
    }
}
