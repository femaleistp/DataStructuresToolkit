using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using DataStructuresToolkit.SortingSearching;
using Xunit;

namespace DataStructuresToolkit.Tests
{
    public class RecursionHelpersTests
    {
        /// <summary>
        /// Tests the Factorial method with valid input.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void Factorial_ValidInput_ReturnExpected()
        {
            // Arrange
            int input = 5;
            int expected = 120;
            // Act
            int result = RecursionHelpers.Factorial(input);
            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the Factorial method with base case input of zero.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void Factorial_BaseCaseZero_ReturnsOne()
        {
            // Arrange
            int input = 0;
            int expected = 1;
            // Act
            int result = RecursionHelpers.Factorial(input);
            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the Factorial method with negative input, expecting an exception.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void Factorial_Negative_Throws()
        {
            // Arrange
            int input = -1;
            bool threwException = false;
            // Act
            try
            { 
                RecursionHelpers.Factorial(input);
            }
            catch (ArgumentException)
            {
                threwException = true;
            }

            // Assert
            Assert.True(threwException);
        }

        /// <summary>
        /// Tests the IsPalindrome method with a palindrome string.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void IsPalindrome_TrueCase()
        {
            // Arrange 
            string input = "aba";
            bool expected = true;
            // Act
            bool result = RecursionHelpers.IsPalindrome(input);
            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the IsPalindrome method with a non-palindrome string.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void IsPalindrome_FalseCase()
        {
            // Arrange
            string input = "abc";
            bool expected = false;
            // Act
            bool result = RecursionHelpers.IsPalindrome(input);
            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests the IsPalindrome method with null input, expecting an exception.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void IsPalindrome_Null_Throws()
        {
            // Arrange
            string input = null;
            bool threwException = false;
            // Act
            try
            { 
                RecursionHelpers.IsPalindrome(input);
            }
            catch (ArgumentNullException)
            {
                threwException = true;
            }
            // Assert
            Assert.True(threwException);
        }

        /// <summary>
        /// Tests the CountFilesRecursively method with nested folders.
        /// </summary>
        /// <remarks>complexity O(n) time and O(d) space, where n is the number of files and d is the depth of the directory tree</remarks>
        [Fact]
        public void CountFilesRecursively_NestedFolders_ReturnCorrectCount()
        {
            // Arrange
            string root = Path.Combine(Path.GetTempPath(), "NestedFolder_Test");
            string sub1 = Path.Combine(root, "Sub1");
            string sub2 = Path.Combine(sub1, "Sub2");
            Directory.CreateDirectory(sub2);
            File.WriteAllText(Path.Combine(root, "a.txt"), "test");
            File.WriteAllText(Path.Combine(sub1, "b.txt"), "test");
            File.WriteAllText(Path.Combine(sub2, "c.txt"), "test");
            // Act  
            int count = RecursionHelpers.CountFilesRecursively(root);
            // Assert
            Assert.Equal(3, count);
        }

        /// <summary>
        /// Tests the CountFilesRecursively method with an empty folder.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void CountFilesRecursively_EmptyFolder_ReturnsZero()
        { 
            // Arrange
            string tempPath = Path.Combine(Path.GetTempPath(), "Empty Folder_Test");
            if (!Directory.Exists(tempPath))
            { 
                Directory.CreateDirectory(tempPath);
            }
            // Act
            int count = RecursionHelpers.CountFilesRecursively(tempPath);
            // Assert
            Assert.Equal(0, count);
            // Cleanup
            Directory.Delete(tempPath, true);
        }
    }
}
