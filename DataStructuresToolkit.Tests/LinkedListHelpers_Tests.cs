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
    }
}
