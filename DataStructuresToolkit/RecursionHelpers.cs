using System;
using System.IO;

namespace DataStructuresToolkit
{
    public class RecursionHelpers
    {
        /// <summary>
        /// Calculates the factorial of a non-negative integer n using recursion.
        /// </summary>
        /// <param name="n">The non-negative integer to calculate the factorial for.</param>
        /// <returns>The factorial of n (n!).</returns>
        /// <exception cref="ArgumentException">Thrown when n is negative.</exception>
        /// <remarks>complexity O(n) time and O(n) space</remarks>
        public static int Factorial(int n)
        {
            // Base case
            if (n < 0)
            { 
                throw new ArgumentException("n must be a non-negative integer."); 
            }

            // Recursive case
            if (n == 0)
            {
                return 1;            
            }

            // Recursive case
            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Determines if a given string is a palindrome using recursion.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown when s is null.</exception>
        /// <remarks>complexity O(n) time and O(n) space</remarks>
        public static bool IsPalindrome(string s)
        {
            // Base case
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            // Recursive case
            if (s.Length <= 1)
            {
                return true;
            }

            // Check first and last characters
            if (s[0] != s[s.Length - 1])
            {
                return false;
            }

            // Recursive case: check the substring without the first and last characters
            return IsPalindrome(s.Substring(1, s.Length - 2));
        }

        /// <summary>
        /// Traverses a directory and prints its structure recursively.
        /// </summary>
        /// <param name="path">The path of the directory to traverse.</param>
        /// <param name="indent">The indentation for the current level (used for formatting).</param>
        /// <remarks>complexity O(n) time and O(d) space, where n is the number of files and directories, and d is the depth of the directory tree.</remarks>
        public static void TraverseDirectory(string path, string indent = "")
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine(indent + "[Missing]" + path);
                return;
            }

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(indent + "- " + Path.GetFileName(file));
            }

            string[] directories = Directory.GetDirectories(path);
            foreach(string dir in directories)
            {
                Console.WriteLine(indent + "> " + Path.GetFileName(dir));
                TraverseDirectory(dir, indent + "  ");
            }
        }
    }
}
