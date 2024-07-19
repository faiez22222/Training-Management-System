using System;

public class Queue
{
    private int[] _queue;
    private int _front;
    private int _rear;
    private int _size;
    private int _capacity;

    public Queue(int capacity)
    {
        _capacity = capacity;
        _queue = new int[capacity];
        _front = 0;
        _rear = -1;
        _size = 0;
    }

    public bool IsFull()
    {
        return _size == _capacity;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public void Enqueue(int item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Queue is full");
        }
        _rear = (_rear + 1) % _capacity;
        _queue[_rear] = item;
        _size++;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        int item = _queue[_front];
        _queue[_front] = default;  // Optional: Clear the slot for garbage collection
        _front = (_front + 1) % _capacity;
        _size--;
        return item;
    }

    public int Front()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return _queue[_front];
    }

    public int Rear()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return _queue[_rear];
    }

    public int Size()
    {
        return _size;
    }

    public int Capacity()
    {
        return _capacity;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }
        Console.Write("Queue elements: ");
        for (int i = 0; i < _size; i++)
        {
            Console.Write(_queue[(_front + i) % _capacity] + " ");
        }
        Console.WriteLine();
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        Queue q = new Queue(5);
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);

        Console.WriteLine("Queue after enqueuing 5 elements:");
        q.Display();
        Console.WriteLine("Front element: " + q.Front());
        Console.WriteLine("Rear element: " + q.Rear());

        q.Dequeue();
        Console.WriteLine("Queue after one dequeue operation:");
        q.Display();

        q.Enqueue(6);
        Console.WriteLine("Queue after enqueuing one more element:");
        q.Display();
        Console.WriteLine("Front element: " + q.Front());
        Console.WriteLine("Rear element: " + q.Rear());
    }
}
