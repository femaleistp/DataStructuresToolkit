/*
Brittany Hancock
IT 415: Data Structures and Algorithms
Instructor: Lenore Montalbano
November 6, 2025
Project 7: Balanced Trees and Priority Queues Toolkit
Reflection

After creating an AVLTree object, we use the Insert method to add an int key. That immediately 
calls the private InsertNode method, where we send the current root and new key. If the root is 
null, it creates a new node and returns it as the root. If the key is less than the current root 
key, it recurses left; if greater, it goes right. After inserting, it updates the height and 
checks the balance factor. There are four rotation cases depending on whether the imbalance is 
left-left, right-right, left-right, or right-left. If no rotation is needed, it returns the node. 
This process repeats for every insert.

I created the first test, Insert_ShouldBalance_AfterRotation(), before the AVLTree class or 
methods existed. I inserted 10, 20, and 30 to force imbalance. With 10 as root, 20 goes right, 
and 30 goes right-right, requiring a rotation. The rotation corrected the balance, making 20 the 
root, 10 the left child, and 30 the right child.

AVL uses node objects, while PriorityQueue stores integers in a list. The heap is simpler, using 
HeapifyUp to bubble values up when enqueueing and HeapifyDown to push larger ones down when 
dequeuing. It’s a min heap, so the smallest value becomes the root. Heapify maintains order, while 
AVL rotations restructure the tree when imbalance occurs.

In a real project, I would use the AVL tree because most real-world needs involve searching. 
O(log n) time is much more scalable than looping through data. AVL trees can store complex objects 
and rebalance automatically after inserts or deletions.
*/


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

            // Case 3: Right Left (perform right rotation on right child, then left rotation)
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Case 4: Left Right (perform left rotation on left child, then right rotation)
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            // No rotation needed
            return node;
        }

        public void PrintTree(AvlNode node, string indent = "", string position = "Root")
        {
            if (node == null)
            {
                return;
            }

            int bf = GetBalance(node);
            Console.WriteLine($"{indent}- {position}: {node.Key} (BF: {bf})");

            PrintTree(node.Left, indent + "  ", "Left child");
            PrintTree(node.Right, indent + "  ", "Right child");
        }

        /// <summary>
        /// Gets the height of a node.
        /// </summary>
        /// <param name="node">The node to get the height of.</param>
        /// <returns>The height of the node.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public int GetHeight(AvlNode node)
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
        public int GetBalance(AvlNode node)
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
