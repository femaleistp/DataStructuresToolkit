using Xunit;
using DataStructuresToolkit;
namespace DataStructuresToolkit.Tests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void EnqueueAndDequeue_ShouldReturnSmallestElement()
        {
            // Arrange
            var pq = new PriorityQueue();
            pq.Enqueue(5); 
            pq.Enqueue(2); 
            pq.Enqueue(8);

            // Act
            int result = pq.Dequeue();

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Enqueue_ShouldMaintainHeapProperty()
        {
            // Arrange
            var pq = new PriorityQueue();
            pq.Enqueue(10);
            pq.Enqueue(4);
            pq.Enqueue(15);
            pq.Enqueue(2);

            // Act
            int first = pq.Dequeue();
            int second = pq.Dequeue();
            int third = pq.Dequeue();
            int fourth = pq.Dequeue();
            // Assert
            Assert.Equal(new[] { 2, 4, 10, 15 }, new[] { first, second, third, fourth });
        }
    }
}
