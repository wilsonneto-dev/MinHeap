namespace HeapLib;

public interface IMinHeap<T> where T : IComparable<T>
{
    int Capacity { get; }
    int Count { get; }

    T? Peek();
    void Push(T value);
}