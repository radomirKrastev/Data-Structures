namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(number);
            var arr = new int[50];
            arr[0] = queue.Peek();
            var keyCounter = 0;

            for (int i = 1; i < 50; i=i+0)
            {
                if (i < 50)
                {
                    arr[i++] = arr[keyCounter]+1;
                }
                else
                {
                    break;
                }

                if (i < 50)
                {
                    arr[i++] = 2 * arr[keyCounter] + 1;
                }
                else
                {
                    break;
                }

                if (i < 50)
                {
                    arr[i++] = arr[keyCounter] + 2;
                }
                else
                {
                    break;
                }

                keyCounter++;
            }
                
            Console.WriteLine(string.Join(" ", arr));
        } 
    }
}
