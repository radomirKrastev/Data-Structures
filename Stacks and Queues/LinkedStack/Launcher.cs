namespace LinkedStack
{
    public class Launcher
    {
        public static void Main()
        {
            LinkedStack<int> arr = new LinkedStack<int>();
            arr.Push(1);
            arr.Push(2);
            arr.Push(3);
            System.Console.WriteLine(arr.Count);
            System.Console.WriteLine(string.Join(" ", arr.ToArray()));
            var item = arr.Pop();
            var item1 = arr.Pop();
            var item2 = arr.Pop();
            var item3 = arr.Pop();
            System.Console.WriteLine(string.Join(" ", arr.ToArray()));
        }
    }
}
