using System;

public class MyHeap<T>
{
    const int root = 1;
    const int minSize = 10;
    public int size = 1;
    public int capacity;

    readonly int multipleArray = 2;
    public T[] values;
    public Func<T, T, bool> Compare;

    public MyHeap(Func<T, T, bool> Compare, int size = minSize)
    {
        this.Compare = Compare;
        values = new T[size];
        capacity = size;
    }

    public void InsertValue(T value)
    {
        
        if (capacity <= size)
        {
            size *= multipleArray;
            Array.Resize(ref values, size * multipleArray);
        }

        values[size] = value;
        ReUp(size);
        size++;
    }

    public T Peek()
    {
        return values[root];
    }

    public T Pop()
    {
        if (size < root)
            throw new NullReferenceException();

        T result = values[root];
        size--;
        values[root] = values[size];
        ReDown(root);
        return result;
    }

    void Swap(int parent, int child)
    {
        T temp = values[parent];
        values[parent] = values[child];
        values[child] = temp;
    }


    void ReUp(int child)
    {
        int parent = child / 2;

        if (parent == 0)
            return;

        if (Compare(values[parent], values[child]))
        {
            Swap(parent, child);
            ReUp(parent);
        }
    }

    void ReDown(int parent)
    {
        int child = parent * 2;

        if (child >= size)
            return;

        if (child + 1 < size && Compare(values[child], values[child + 1]))
            child = child + 1;

        if (Compare(values[parent], values[child]))
        {
            Swap(child, parent);
            ReDown(child);
        }

    }


}


public class CustomPriorityQue<T>
{
    MyHeap<T> heap;

    public int Capacity
    {
        get => heap.capacity;
    }
    public int Size
    {
        get => heap.size - 1;
    }

    public CustomPriorityQue(Func<T, T, bool> Compare)
    {
        heap = new MyHeap<T>(Compare);
    }

    public void Enque(T item)
    {
        heap.InsertValue(item);
    }
    public T Deque()
    {
        return heap.Pop();
    }
    public T Peek()
    {
        return heap.Peek();
    }
    public void Clear()
    {
        heap.size = 1;
        heap.values = new T[heap.capacity];
    }

    public bool Empty()
    {
        return heap.size == 1;
    }

}