using System;
using DataStructuresToolkit.StacksQueues;
using Xunit;

namespace DataStructuresToolkit.Tests
{
    public class MyQueueTests
    {
        /// <summary>
        /// Test to ensure Enqueue increases count and Peek shows the first item
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
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

        /// <summary>
        /// Test to ensure Peek returns the first item without removing it
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
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

        /// <summary>
        /// Test to ensure exceptions are thrown when dequeuing or peeking from an empty queue
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
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

        /// <summary>
        /// Test to ensure that wraparound with resize preserves FIFO order
        /// </summary>
        /// <remarks>complexity O(n) time and O(n) space</remarks>
        [Fact]
        public void Wraparound_With_Resize_Preserves_FIFO_Order()
        {
            // Arrange
            var q = new MyQueue<int>(3);
            // Act
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3); // Queue is now full

            int firstOut = q.Dequeue(); // Expect 1 (moves head forward)

            int secondOut = q.Dequeue(); // Expect 2
            q.Enqueue(4); // Tail wraps to index 0
            q.Enqueue(5); // Queue full again
            int countBeforeResize = q.Count; // Should be 3
            q.Enqueue(6); // This should trigger a resize

            int a = q.Dequeue(); // Expect 3
            int b = q.Dequeue(); // Expect 4
            int c = q.Dequeue(); // Expect 5
            int d = q.Dequeue(); // Expect 6
            // Assert
            Assert.Equal(1, firstOut);
            Assert.Equal(2, secondOut);
            Assert.Equal(3, countBeforeResize);
            Assert.Equal(3, a);
            Assert.Equal(4, b);
            Assert.Equal(5, c);
            Assert.Equal(6, d);
            Assert.Equal(0, q.Count);
        }
    }
}
