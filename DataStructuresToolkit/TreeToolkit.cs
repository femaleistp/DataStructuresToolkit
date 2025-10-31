using System;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Contains basic binary tree and BST implementation with traversal and height utilities.
    /// </summary>
    public class TreeToolkit
    {
        
    }

    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        /// <summary>
        /// Initializes a new instance of the TreeNode class with the specified value.
        /// </summary>
        /// <param name="value">The integer value of the node.</param>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Builds a sample binary tree for teaching purposes.
        /// </summary>
        /// <returns>The root node of the constructed binary tree.</returns>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public static TreeNode BuildTeachingTree()
        { 
            TreeNode root = new TreeNode(38);
            root.Left = new TreeNode(27);
            root.Right = new TreeNode(43);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(9);
            return root;
        }

        /// <summary>
        /// Performs an inorder traversal of the binary tree (left, root, right) and prints the node values.
        /// </summary>
        /// <param name="node">The root node of the binary tree.</param>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public static void Inorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Inorder(node.Left);
            Console.WriteLine(node.Value + " ");
            Inorder(node.Right);
        }

        /// <summary>
        /// Performs a preorder traversal of the binary tree (root, left, right) and prints the node values.
        /// </summary>
        /// <param name="node">The root node of the binary tree.</param>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public static void Preorder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Value + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        /// <summary>
        /// Performs a postorder traversal of the binary tree (left, right, root) and prints the node values.
        /// </summary>
        /// <param name="node">The root node of the binary tree.</param>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public static void Postorder(TreeNode node)
        { 
            if (node == null)
            {
                return;
            }
            Postorder(node.Left);
            Postorder(node.Right);
            Console.WriteLine(node.Value + " ");
        }

        /// <summary>
        /// Calculates the height of the binary tree.
        /// </summary>
        /// <param name="node">The root node of the binary tree.</param>
        /// <returns>The height of the tree.</returns>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public static int Height(TreeNode node)
        {
            if (node == null)
            {
                return -1; // Height of empty tree is -1
            }
            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// Calculates the depth of a target value in the binary tree.
        /// </summary>
        /// <param name="root">The root node of the binary tree.</param>
        /// <param name="target">The target value to find.</param>
        /// <returns>The depth of the target value, or -1 if not found.</returns>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public static int Depth(TreeNode root, int target)
        {
            if (root == null)
            {
                return -1; // Target not found
            }

            if(root.Value == target)
            {
                return 0; // Target found at root
            }

            int leftDepth = Depth(root.Left, target);
            if (leftDepth >= 0)
            {
                return leftDepth + 1; // Target found in left subtree
            }

            int rightDepth = Depth(root.Right, target);
            if (rightDepth >= 0)
            {
                return rightDepth + 1; // Target found in right subtree
            }

            return -1; // Target not found in either subtree
        }
    }

    /// <summary>
    /// Basic Binary Search Tree (BST) implementation.
    /// </summary>
    public class Bst
    {
        /// <summary>
        /// The root node of the BST.
        /// </summary>
        public TreeNode Root;

        /// <summary>
        /// Initializes a new instance of the Bst class.
        /// </summary>
        /// <remarks>Complexity time O(1) and space O(1).</remarks>
        public Bst()
        {
            Root = null;
        }

        /// <summary>
        /// Helper method to insert a value recursively into the BST.
        /// </summary>
        /// <param name="value">The integer value to insert.</param>
        /// <remarks>Complexity time O(h) and space O(h) where h is the height of the tree.</remarks>
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        /// <summary>
        /// Recursively inserts a value into the BST.
        /// </summary>
        /// <param name="node">The current node in the BST.</param>
        /// <param name="value">The integer value to insert.</param>
        /// <returns>The updated node after insertion.</returns>
        /// <remarks>Complexity time O(h) and space O(h) where h is the height of the tree.</remarks>
        private TreeNode InsertRecursive(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = InsertRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = InsertRecursive(node.Right, value);
            }
            else
            {
                // Duplicate values are not allowed in this BST implementation.
            }

            return node;
        }

        /// <summary>
        /// Checks if the BST contains a specific value.
        /// </summary>
        /// <param name="value">The integer value to search for.</param>
        /// <returns>The true if the value is found; otherwise, false.</returns>
        /// <remarks>Complexity time O(h) and space O(1) where h is the height of the tree.</remarks>
        public bool Contains(int value)
        {
            TreeNode current = Root;
            while (current != null)
            {
                if (value == current.Value)
                {
                    return true;
                }
                else if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return false;
        }

        /// <summary>
        /// Calculates the height of the BST.
        /// </summary>
        /// <returns>The height of the BST.</returns>
        /// <remarks>Complexity time O(n) and space O(h) where n is the number of nodes and h is the height of the tree.</remarks>
        public int Height()
        { 
            return TreeNode.Height(Root);   
        }
    }
}
