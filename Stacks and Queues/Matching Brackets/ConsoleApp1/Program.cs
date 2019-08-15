namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();
            var example = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";

            for (int i = 0; i < example.Length; i++)
            {
                if (example[i] == '(')
                {
                    stack.Push(i);
                }
                else if (example[i] == ')')
                {
                    var startPoint = stack.Pop();
                    var result = example.Substring(startPoint, i - startPoint+1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
