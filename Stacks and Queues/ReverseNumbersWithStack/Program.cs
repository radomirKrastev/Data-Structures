namespace ReverseNumbersWithStack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public  static void Main()
        {
            var data = Console.ReadLine();      
            if (data == "(empty)")
            {
                Console.WriteLine(data);
            }
            else
            {
                var stack = new Stack<int>();
                int [] elements = data
                    .Split(new string [] { " " },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < elements.Length; i++)
                {
                    stack.Push(elements[i]);
                }

                while (stack.Count != 0)
                {
                    if (stack.Count == 1)
                    {
                        Console.Write(stack.Pop());
                        break;
                    }
                    Console.Write(stack.Pop()+" ");
                }
            }
        }
    }
}
