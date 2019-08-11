namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var longestSubsequence = 0;
            var sequence = new List<int>();

            var helpSequence = new List<int>();
            helpSequence.Add(data[0]);

            if (data.Length == 0)
            {
                Console.WriteLine(helpSequence[0]);
            }

            else
            {
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] == helpSequence[0])
                    {
                        helpSequence.Add(data[i]);
                    }

                    if (data[i] != helpSequence[0] || i + 1 >= data.Length)
                    {
                        if (helpSequence.Count > longestSubsequence)
                        {
                            longestSubsequence = helpSequence.Count();

                            sequence.RemoveRange(0, sequence.Count);
                            for (int j = 0; j < helpSequence.Count; j++)
                            {
                                sequence.Add(helpSequence[0]);
                            }
                        }

                        helpSequence = new List<int> { data[i] };
                    }
                }

                Console.WriteLine(string.Join(" ", sequence));
            }            
        }
    }
}
