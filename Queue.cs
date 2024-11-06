public class Queue<T> : IQueue<T> where T : struct
{
    private T[] _items;
    private int _head;
    private int _tail;
    private int _count;
    private readonly int _capacity;

    public Queue(int capacity = 10)
    {
        _capacity = capacity;
        _items = new T[capacity];
        _head = 0;
        _tail = -1;
        _count = 0;
    }

    public void Enqueue(T item)
    {
        if (_count == _capacity)
        {
            throw new InvalidOperationException("full");
        }
        _tail = (_tail + 1) % _capacity;
        _items[_tail] = item;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("empty");
        }
        T item = _items[_head];
        _head = (_head + 1) % _capacity;
        _count--;
        return item;
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }
}
