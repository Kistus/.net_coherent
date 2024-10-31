public class Program
{
    public static void Main(string[] args)
    {
        IQueue<int> queue = new Queue<int>(5);

        queue.Enqueue(1);
        queue.Enqueue(3);
        queue.Enqueue(5);
        queue.Enqueue(7);
        while (!queue.IsEmpty())
        {
            Console.WriteLine(queue.Dequeue());
        }

        queue.Enqueue(1);
        queue.Enqueue(3);
        queue.Enqueue(5);
        queue.Enqueue(7);

        IQueue<int> tailQueue = queue.Tail();
        while (!tailQueue.IsEmpty())
        {
            Console.WriteLine(tailQueue.Dequeue());
        }
    }
}
