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
    }
}
