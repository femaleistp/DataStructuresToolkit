using System;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Represents an AVL tree, a self-balancing binary search tree.
    /// </summary>
    public class AvlTree
    {
        /// <summary>
        /// Gets the root node of the AVL tree.
        /// </summary>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public AvlNode Root { get; private set; }

        /// <summary>
        /// Inserts a key into the AVL tree and balances the tree if necessary.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <remarks>Complexity time O(log n) and space O(log n) where n is the number of nodes in the tree.</remarks>
        public void Insert(int key)
        {
            Root = InsertNode(Root, key);
        }

        /// <summary>
        /// Helper method to check if a key exists in the tree.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>The node if found; otherwise, null.</returns>
        /// <remarks>Complexity time O(log n) and space O(log n) where n is the number of nodes in the tree.</remarks>
        public bool Contains(int key)
        { 
            return ContainsNode(Root, key);
        }

        /// <summary>
        /// Helper method to check if a key exists in the subtree rooted at the given node.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="key">The key to search for.</param>
        /// <returns>The node if found; otherwise, null.</returns>
        /// <remarks>Complexity time O(log n) and space O(log n) where n is the number of nodes in the tree.</remarks>
        private bool ContainsNode(AvlNode node, int key)
        { 
            if (node == null)
            {
                return false;
            }

            if (key == node.Key)
            {
                return true;
            }

            if (key < node.Key)
            {
                return ContainsNode(node.Left, key);
            }

            else
            {
                return ContainsNode(node.Right, key);
            }
        }

        /// <summary>
        /// Helper method to insert a node and perform rotations if necessary.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="key">The key to insert.</param>
        /// <returns>The new root of the subtree.</returns>
        /// <remarks>Complexity time O(log n) and space O(log n) where n is the number of nodes in the tree.</remarks>
        private AvlNode InsertNode(AvlNode node, int key)
        {
            // Perform normal BST insertion
            if (node == null)
            {
                return new AvlNode(key);
            }

            if (key < node.Key)
            {
                node.Left = InsertNode(node.Left, key);
            }

            else if (key > node.Key) 
            {
                node.Right = InsertNode(node.Right, key);
            }

            // Update height of this ancestor node
            UpdateHeight(node);

            // Get the balance factor
            int balance = GetBalance(node);

            // Rotate if unbalanced
            // Case 1: Right Right (perform left rotation)
            if (balance < -1 && key > node.Right.Key)
            {
                return RotateLeft(node);
            }
            // Case 2: Left Left (perform right rotation)
            if (balance > 1 && key < node.Left.Key)
            {
                return RotateRight(node);
            }
            // No rotation needed
            return node;
        }

        /// <summary>
        /// Gets the height of a node.
        /// </summary>
        /// <param name="node">The node to get the height of.</param>
        /// <returns>The height of the node.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        private int GetHeight(AvlNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        /// <summary>
        /// Calculates the balance factor of a node.
        /// </summary>
        /// <param name="node">The node to calculate the balance factor for.</param>
        /// <returns>The balance factor of the node.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        private int GetBalance(AvlNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        /// <summary>
        /// Updates the height of a node based on its children's heights.
        /// </summary>
        /// <param name="node">The node to update.</param>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public void UpdateHeight(AvlNode node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        /// <summary>
        /// Performs a right rotation on the given node.
        /// </summary>
        /// <param name="y">The node to rotate.</param>
        /// <returns>The new root after rotation.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        private AvlNode RotateRight(AvlNode y)
        {
            AvlNode x = y.Left;
            AvlNode T2 = x.Right;
            // Perform rotation
            x.Right = y;
            y.Left = T2;
            // Update heights
            UpdateHeight(y);
            UpdateHeight(x);
            // Return new root
            return x;
        }

        /// <summary>
        /// Performs a left rotation on the given node.
        /// </summary>
        /// <param name="x">The node to rotate.</param>
        /// <returns>The new root after rotation.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        private AvlNode RotateLeft(AvlNode x)
        {
            AvlNode y = x.Right;
            AvlNode T2 = y.Left;
            // Perform rotation
            y.Left = x;
            x.Right = T2;
            // Update heights
            UpdateHeight(x);
            UpdateHeight(y);
            // Return new root
            return y;
        }
    }

    /// <summary>
    /// Represents a node in an AVL tree.
    /// </summary>
    public class AvlNode
    {
        public int Key;
        public AvlNode Left;
        public AvlNode Right;
        public int Height;

        public AvlNode(int key)
        {
            Key = key;
            Left = null;
            Right = null;
            Height = 1; // New node is initially added at leaf
        }
    }
}
