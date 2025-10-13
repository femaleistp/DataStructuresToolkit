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

        // Test to ensure Dequeue returns the first item and decreases the count
        // This verifies the FIFO behavior of the queue
        [Fact]
        public void Dequeue_ReturnsFirst_And_DecreasesCount()
        { 
            // Arrange
            var q = new MyQueue<string>();
            q.Enqueue("A");
            q.Enqueue("B");
            // Act
            string first = q.Dequeue();
            // Assert
            Assert.Equal("A", first);
            Assert.Equal(1, q.Count);
            Assert.Equal("B", q.Peek());
        }

        // Test to ensure exceptions are thrown when dequeuing or peeking from an empty queue
        // This verifies the queue's error handling
        [Fact]
        public void Peek_And_Dequeue_OnEmpty_ThrowInvalidOperationException()
        { 
            // Arrange
            var q = new MyQueue<int>();
            // Act
            Exception peekEx = Record.Exception(delegate { q.Peek(); });
            Exception dequeueEx = Record.Exception(delegate { q.Dequeue(); });
            // Assert
            Assert.IsType<InvalidOperationException>(peekEx);
            Assert.IsType<InvalidOperationException>(dequeueEx);
        }
    }
}
