using System;
using Xunit;
using DataStructuresToolkit.StacksQueues;

namespace DataStructuresToolkit.Tests
{
    public class MyStackTests
    {
        [Fact]
        public void Push_IncreasesCount_AndPeekShowsTop()
        {
            // Arrange
            var stack = new MyStack<int>();
            // Act
            stack.Push(10);
            stack.Push(20);
            // Assert
            Assert.Equal(2, stack.Count);
            Assert.Equal(20, stack.Peek()); 
        }

        [Fact]
        public void Pop_returnsLastPushed_AndDecreasesCount()
        {
            // Arrange
            var stack = new MyStack<string>();
            stack.Push("A");
            stack.Push("B");
            // Act
            string popped = stack.Pop();
            // Assert
            Assert.Equal("B", popped);
            Assert.Equal(1, stack.Count);
            Assert.Equal("A", stack.Peek());
        }

    }
}
