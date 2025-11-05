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
            Assert.True(IsBalanced(tree.Root), "AVL tree is not balanced after multiple insertions");
        }

        [Fact]
        public void GetBalance_ShouldReturnCorrectBalanceFactor()
        {
            // Arrange
            var tree = new AvlTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(5);

            // Act
            var root = tree.Root;
            int bf = tree.GetBalance(root);

            // Assert
            // Left subtree has height 1 (node 5), right subtree has height 1 (node 20), so balance factor is 0
            Assert.Equal(0, bf); // The tree should be balanced
        }

        
        // Helper methods 

        /// <summary>
        /// Helper method to check if the tree is balanced.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <returns>The balance status of the tree.</returns>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes in the tree and h is the height of the tree.</remarks>
        private static bool IsBalanced(AvlNode node)
        {
            if (node == null)
            {
                return true;
            }
            var tempTree = new AvlTree();
            int balance = tempTree.GetBalance(node);
            // Checking here if the balance factor is within the allowed range [-1, 1]
            return Math.Abs(balance) <= 1
                && IsBalanced(node.Left)
                && IsBalanced(node.Right);
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
