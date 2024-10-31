public static class QueueExtensions
{
    public static IQueue<T> Tail<T>(this IQueue<T> queue)
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("empty");
        }

        Queue<T> newQueue = new Queue<T>();
        queue.Dequeue();

        while (!queue.IsEmpty())
        {
            newQueue.Enqueue(queue.Dequeue());
        }

        return newQueue;
    }
}
