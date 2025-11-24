using DataStructuresToolkit;
using Xunit;

namespace DataStructuresToolkit.Tests
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void AddFirst_ShouldInsertAtHead()
        {
            // Arrange
            var list = new SinglyLinkedList<int>();

            // Act
            list.AddFirst(10);
            list.AddFirst(20);

            // Assert
            Assert.Equal(20, list.Head.Data);
            Assert.Equal(10, list.Head.Next.Data);
        }

        [Fact]
        public void Traverse_ShouldReturnSequence()
        {
            // Arrange
            var list = new SinglyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Act  
            var values = list.Traverse();

            // Assert
            Assert.Equal(new[] { 1, 2, 3 }, values);
        }
    }
}
