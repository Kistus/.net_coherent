public static class QueueExtensions
{
    public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        List<T> items = new List<T>();
        while (!queue.IsEmpty())
        {
            items.Add(queue.Dequeue());
        }
        Queue<T> newQueue = new Queue<T>();
        for (int i = 1; i < items.Count; i++)
        {
            newQueue.Enqueue(items[i]);
        }
        foreach (var item in items)
        {
            queue.Enqueue(item);
        }
        return newQueue;
    }
}
