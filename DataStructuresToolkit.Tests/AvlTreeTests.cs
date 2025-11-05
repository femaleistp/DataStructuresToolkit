using Xunit;
using DataStructuresToolkit;
namespace DataStructuresToolkit.Tests
{
    public class AvlTreeTests
    {
        [Fact]
        public void Insert_ShouldBalance_AfterRotation()
        {
            // Arrange
            var tree = new AvlTree();

            // Act
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            // Assert 
            Assert.Equal(20, tree.Root.Key);
            Assert.Equal(10, tree.Root.Left.Key);
            Assert.Equal(30, tree.Root.Right.Key);
        }

        [Fact]
        public void Contains_ShouldReturnTrue_IfValueExists()
        {
            // Arrange
            var tree = new AvlTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            // Act
            bool exists10 = tree.Contains(10);
            bool exists20 = tree.Contains(20);
            bool exists5 = tree.Contains(5);
            bool exists15 = tree.Contains(15);

            // Assert
            Assert.True(exists10);
            Assert.True(exists20);
            Assert.True(exists5);
            Assert.False(exists15);
        }
    }
}
