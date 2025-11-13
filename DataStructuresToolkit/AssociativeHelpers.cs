using System;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Helper methods for associative containers like Dictionary and HashSet.
    /// </summary>
    public static class AssociativeHelpers
    {
        /// <summary>
        /// Builds a simple phone book dictionary.
        /// </summary>
        /// <returns>The phone book as a dictionary.</returns>
        /// <remarks>Complexity time O(1) and space complexity O(1)</remarks>
        public static Dictionary<string, string> BuildPhoneBook()
        {
            return new Dictionary<string, string>
            {
                ["Alice"] = "555-1234",
                ["Bob"] = "555-5678",
                ["Charlie"] = "555-9012"
            };
        }

        /// <summary>
        /// Builds a set of fruits.
        /// </summary>
        /// <returns>The fruit set as a HashSet.</returns>
        /// <remarks>Complexity time O(1) and space complexity O(1)</remarks>
        public static HashSet<string> BuildFruitSet()
        {
            return new HashSet<string>
            {
                "Apple",
                "Banana",
                "Orange",
                "Apple" // Duplicate, will not be added
            };
        }
    }
}
