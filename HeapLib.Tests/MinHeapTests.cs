using FluentAssertions;
using HeapLib.Array;
using Xunit;

namespace HeapLib.Tests;

public class MinHeapTests
{
    [Theory]
    [InlineData(4, 1, new int[] { 5, 10, 15, 1 })]
    [InlineData(6, 1, new int[] { 2, 3, 4, 10, 6, 1 })]
    [InlineData(5, 5, new int[] { 20, 30, 40, 10, 5 })]
    public void Push_ReceiveNumbersArray_UpdatePeekAndCount(int expectedCount, int expectedPeek, int[] numbers)
    {
        var minHeap = new MinHeap<int>();

        foreach(var number in numbers)
            minHeap.Push(number);

        minHeap.Count.Should().Be(expectedCount);
        minHeap.Peek().Should().Be(expectedPeek);
    }

    [Theory]
    [InlineData(new int[] { 5, 10, 15, 1 })]
    [InlineData(new int[] { 2, 3, 4, 10, 6, 1 })]
    [InlineData(new int[] { 20, 30, 40, 10, 5 })]
    [InlineData(new int[] { -20, -30, -40, -10, -5 })]
    public void Pop_ReceiveNumbersArray_ShouldPopInOrder(int[] numbers)
    {
        var minHeap = new MinHeap<int>();
        var sorted = new List<int>(numbers).Order().ToList();

        foreach(var number in numbers)
            minHeap.Push(number);

        foreach(var expectedNumber in sorted)
        {
            var popped = minHeap.Pop();
            popped.Should().Be(expectedNumber);
        }
    }

    [Fact]
    public void test()
    {
        var h = new PriorityQueue<int, int>();
        h.Enqueue(1, 1);
        h.Enqueue(2, 2);
        h.Enqueue(3, 3);
        h.Enqueue(4, 4);
        h.Enqueue(5, 5);
        h.Enqueue(6, 6);

        h.Dequeue();
    }
}
