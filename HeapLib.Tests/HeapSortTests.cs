using FluentAssertions;
using HeapLib.Array;
using Xunit;

namespace HeapLib.Tests;

public class HeapSortTests
{
    [Theory]
    [InlineData(new int[] { 2, 3, 4, 10, 6, 1 }, new int[] { 2, 3, 4, 10, 6, 1 })]
    [InlineData(new int[] { 20, 30, 40, 10, 5 }, new int[] { 2, 3, 4, 10, 6, 1 })]
    public void Push_ReceiveNumbersArray_UpdatePeekAndCount(int[] numbers, int[] expected)
    {
        //var minHeap = new MinHeap<int>();

        //foreach(var number in numbers)
        //    minHeap.Push(number);

        //minHeap.Count.Should().Be(expectedCount);
        //minHeap.Peek().Should().Be(expectedPeek);
    }
}
