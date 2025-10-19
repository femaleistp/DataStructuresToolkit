using System;
using Xunit;
using DataStructuresToolkit.StacksQueues;

namespace DataStructuresToolkit.Tests
{
    public class MyStackTests
    {
        /// <summary>
        /// Tests for MyStack<T> class
        /// </summary>
        /// <remarks>Tests cover basic stack operations and edge cases.</remarks>
        /// <remarks>Time complexity O(1) for basic operations, O(n) for resizing.</remarks>
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

        /// <summary>
        /// Tests Pop method of MyStack<T>
        /// </summary>
        /// <remarks>Tests cover popping items and stack behavior.</remarks>
        /// <remarks>complexity O(1) for pop operation.</remarks>
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

        /// <summary>
        /// Tests Peek and Pop on an empty stack
        /// </summary>
        /// <remarks>complexity O(1) for both operations.</remarks>
        [Fact]
        public void Peek_And_Pop_OnEmpty_ThrowInvalidOperationsException()
        {
            // Arrange
            var stack = new MyStack<int>();
            // Act
            Exception peekException = Record.Exception(delegate { stack.Peek(); });
            Exception popException = Record.Exception(delegate { stack.Pop(); });
            // Assert
            Assert.IsType<InvalidOperationException>(peekException);
            Assert.IsType<InvalidOperationException>(popException);
        }

        /// <summary>
        /// Tests pushing many items to trigger resize
        /// </summary>
        /// <remarks>complexity O(n) for resizing operation.</remarks>
        [Fact]
        public void Many_Items_TriggersResize_And_KeepsOrder()
        { 
            // Arrange
            var stack = new MyStack<int>(2); // Start with small capacity to force resize
            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3); // This should trigger a resize
            int firstPop = stack.Pop();
            int secondPop = stack.Pop();
            int thirdPop = stack.Pop();
            // Assert
            Assert.Equal(0, stack.Count);
            Assert.Equal(3, firstPop);
            Assert.Equal(2, secondPop);
            Assert.Equal(1, thirdPop);
        }
    }
}
