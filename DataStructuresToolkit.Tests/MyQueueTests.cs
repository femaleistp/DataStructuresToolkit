using System;
using DataStructuresToolkit.StacksQueues;
using Xunit;

namespace DataStructuresToolkit.Tests
{
    public class MyQueueTests
    {
        // Test to ensure Enqueue increases count and Peek shows the first item
        // This verifies that items are added correctly and the front is accessible
        [Fact]
        public void Enqueue_IncreasesCount_And_Peek_ShowsFirst()
        {
            // Arrange
            var q = new MyQueue<int>();
            // Act
            q.Enqueue(10);
            q.Enqueue(20);
            // Assert
            Assert.Equal(2, q.Count);
            Assert.Equal(10, q.Peek());
        }
    }
}
