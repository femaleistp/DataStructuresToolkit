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

        [Fact]
        public void Insert_ShouldKeepTreeBalanced_AfterMultipleInsertions()
        {
            // Arrange
            var tree = new AvlTree();

            // Act
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(25);
            tree.Insert(40);
            tree.Insert(50);

            // Assert
            bool IsBalanced(AvlNode node)
            { 
                if (node == null)
                {
                    return true;
                }
                int balance = GetBalance(node);
                // Checking here if the balance factor is within the allowed range [-1, 1]
                return Math.Abs(balance) <= 1 
                    && IsBalanced(node.Left) 
                    && IsBalanced(node.Right);
            }

            int GetHeight(AvlNode node)
            {
                if (node == null)
                {
                    return 0;
                }

                return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
            }

            int GetBalance(AvlNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return GetHeight(node.Left) - GetHeight(node.Right);
            }

            Assert.True(IsBalanced(tree.Root), "AVL tree is not balanced after multiple insertions");
        }
    }

    public class AvlTreeHeightTests
    {
        [Fact]
        public void Insert_ShouldMaintainCorrectNodeHeights()
        {
            // Arrange
            var tree = new AvlTree();

            // Act
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            // Assert
            Assert.Equal(2, tree.Root.Height);          // Root should be height of 2
            Assert.Equal(1, tree.Root.Left.Height);     // Left child should be height of 1
            Assert.Equal(1, tree.Root.Right.Height);    // Right child should be height of 1 
        }

    }
}
