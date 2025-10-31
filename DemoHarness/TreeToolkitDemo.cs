using System;
using DataStructuresToolkit;

namespace DemoHarness
{
    public class TreeToolkitDemo
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("=== TreeToolkit Demo ===\n");

            // Build and Test Teaching Tree
            Console.WriteLine("Building Teaching Tree...");
            TreeNode root = TreeNode.BuildTeachingTree();
            Console.WriteLine("\nInorder Traversal of the Teaching Tree (Left, Root, Right):");
            TreeNode.Inorder(root);

            Console.WriteLine("\nPreorder Traversal of the Teaching Tree (Root, Left, Right):");
            TreeNode.Preorder(root);

            Console.WriteLine("\nPostorder Traversal of the Teaching Tree (Left, Right, Root):");
            TreeNode.Postorder(root);

            Console.WriteLine($"\nHeight of Tree: {TreeNode.Height(root)}");
            Console.WriteLine($"Depth(38): {TreeNode.Depth(root, 38)}");
            Console.WriteLine($"Depth(27): {TreeNode.Depth(root, 27)}");
            Console.WriteLine($"Depth(43): {TreeNode.Depth(root, 43)}");
            Console.WriteLine($"Depth(3): {TreeNode.Depth(root, 3)}");
            Console.WriteLine($"Depth(9): {TreeNode.Depth(root, 9)}");

            // Test BST Insertion and Search
            Console.WriteLine("\n\n=== Binary Search Tree (BST) Tests ===");
            Bst bst = new Bst();

            int[] values = { 50, 30, 70, 20, 40, 60, 80 };
            Console.WriteLine("Inserting sequence: " + string.Join(", ", values));
            foreach (int val in values)
            {
                bst.Insert(val);
            }

            Console.WriteLine("Contains(40): " + bst.Contains(40));  // True
            Console.WriteLine("Contains(25): " + bst.Contains(25));  // False

            Console.WriteLine($"BST Height: {bst.Height()}");

            // Skewed Tree Test
            Console.WriteLine("\nInserting sorted sequence (10,20,30,40,50) to show skewed tree...");
            Bst skewedBst = new Bst();
            int[] sorted = { 10, 20, 30, 40, 50 };
            foreach (int val in sorted)
            {
                skewedBst.Insert(val);
            }

            Console.WriteLine($"Height of skewed tree: {skewedBst.Height()}");  // Should be 4 (n-1 for n nodes)



        }
    }
}
