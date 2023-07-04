using System.Collections.Generic;

namespace HeapLib.Array;

public class MinHeap<T> : IMinHeap<T> where T : IComparable<T>
{
    public int Count { get; private set; }
    public int Capacity { get; private set; }

    private T[] _bucket = System.Array.Empty<T>();

    public MinHeap(int capacity = 16)
    {
        Capacity = capacity;
        Count = 0;
        _bucket = new T[Capacity];
    }

    public T? Peek() => Count > 0 ? _bucket[0] : default(T);

    public T Pop()
    {
        var popped = _bucket[0];

        Count--;
        if(Count == 0)
            return popped;

        _bucket[0] = _bucket[Count];
        var i = 0;
        var leftChildIndex = GetLeftChildIndex(i);
        var rightChildIndex = GetRightChildIndex(i);

        while(leftChildIndex < Count)
        {
            var smaller = 
                    rightChildIndex < Count &&
                    _bucket[rightChildIndex].CompareTo(_bucket[leftChildIndex]) < 0 ?
                    
                rightChildIndex : leftChildIndex;

            if(_bucket[i].CompareTo(_bucket[smaller]) < 0)
            {
                break;
            }

            (_bucket[i], _bucket[smaller]) = (_bucket[smaller], _bucket[i]);
            i = smaller;
            leftChildIndex = GetLeftChildIndex(i);
            rightChildIndex = GetRightChildIndex(i);
        }

        return popped;
    }

    public void Push(T value)
    {
        if(Count >= Capacity)
            ExpandBucket();

        var index = Count;
        _bucket[index] = value;
        var parentIndex = GetParentIndex(index);

        while(_bucket[index].CompareTo(_bucket[parentIndex]) < 0)
        {
            _bucket[index] = _bucket[parentIndex];
            _bucket[parentIndex] = value;
            index = parentIndex;
            parentIndex = GetParentIndex(index);
        }

        Count++;
    }

    private static int GetLeftChildIndex(int index) => (2 * index) + 1;
    private static int GetRightChildIndex(int index) => (2 * index) + 2;
    private static int GetParentIndex(int index) => (index - 1) / 2;

    private void ExpandBucket()
    {
        Capacity *= 2;
        var expandedBucket = new T?[Capacity];
        for(int i = 0; i < _bucket.Length; i++)
            expandedBucket[i] = _bucket[i];
        _bucket = expandedBucket;
    }
}
