using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
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
        /// Tests the TraverseDirectory method with a missing directory, expecting a specific message.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void TraverseDirectory_MissingDirectory_PrintMessage()
        { 
            // Arrange
            string fakePath = "Z:\\This\\Path\\Does\\Not\\Exist";
            string output;
            // Act
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                RecursionHelpers.TraverseDirectory(fakePath);
                output = writer.ToString();
            }
            // Assert
            Assert.Contains("[Missing]", output);
        }

        /// <summary>
        /// Tests the TraverseDirectory method with an empty directory, expecting no extra output.
        /// </summary>
        /// <remarks>complexity O(1) time and O(1) space</remarks>
        [Fact]
        public void TraverseDirectory_EmptyDirectory_PrintsNothingExtra()
        {
            // Arrange
            string tempPath = Path.Combine(Path.GetTempPath(), "EmptyTestFolder");
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            string output;
            // Act
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                RecursionHelpers.TraverseDirectory(tempPath);
                output = writer.ToString();
            }

            // Assert
            Assert.DoesNotContain("[Missing]", output);
            // Cleanup
            Directory.Delete(tempPath, true);
        }
    }
}
