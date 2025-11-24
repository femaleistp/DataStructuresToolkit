using DataStructuresToolkit;
using Xunit;

namespace DataStructuresToolkit.Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void AddFirst_ShouldInsertAtHead()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            // Act
            list.AddFirst(10);
            list.AddFirst(20);
            // Assert
            Assert.Equal(20, list.Head.Data);
            Assert.Equal(10, list.Head.Next.Data);
            Assert.Null(list.Head.Prev);
        }

        [Fact]
        public void AddLast_ShouldInsertAtTail()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            // Act
            list.AddLast(10);
            list.AddLast(20);
            // Assert
            Assert.Equal(20, list.Tail.Data);
            Assert.Equal(10, list.Head.Data);
            Assert.Equal(20, list.Head.Next.Data);
            Assert.Equal(10, list.Tail.Prev.Data);
        }

        [Fact]
        public void TraverseForward_ShouldReturnCorrectSequence()
        {
            //Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Act
            var result = list.TraverseForward();

            // Assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void TraverseBackward_ShouldReturnCorrectSequence()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            // Act
            var result = list.TraverseBackward();

            // Assert
            Assert.Equal(new[] { 3, 2, 1 }, result);
        }

        [Fact]
        public void Remove_ShouldDetachNodeProperly()
        {
            // Arrange
            var list = new DoublyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            var middle = list.Head.Next; // Node with value 20

            // Act
            list.Remove(middle);

            // Assert
            Assert.Equal(10, list.Head.Data);
            Assert.Equal(30, list.Head.Next.Data);
            Assert.Equal(10, list.Tail.Prev.Data);
        }
    }
}
