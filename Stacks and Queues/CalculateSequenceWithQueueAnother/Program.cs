namespace CalculateSequenceWithQueueAnother
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
            var elementCounter = 0;

            while(queue.Count>0)
            {
                if (elementCounter == 50)
                {
                    break;
                }
                arr[elementCounter] = queue.Dequeue();

                queue.Enqueue(arr[elementCounter] + 1);
                queue.Enqueue(2*arr[elementCounter] + 1);
                queue.Enqueue(arr[elementCounter] + 2);
                elementCounter++;
            }

            Console.WriteLine(string.Join(", ",arr));
        }
    }
}
