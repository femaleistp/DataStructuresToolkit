using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Array, string, and list helper methods based on Lab 2 logic.
    /// </summary>
    public static class ArrayStringListHelpers
    {
        // ========= ARRAYS =========

        /// <summary>
        /// Inserts a value into the middle (or any index) of an array by shifting elements right.
        /// The last element is overwritten in a fixed-size array.
        /// </summary>
        /// <param name="arr">Target array.</param>
        /// <param name="index">Zero-based index (0..arr.Length-1).</param>
        /// <param name="value">Value to insert.</param>
        /// <remarks>O(n) time, O(1) space.</remarks>
        public static void InsertIntoArray(int[] arr, int index, int value)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            // Shift elements to the right, starting from the end.
            for (int i = arr.Length - 1; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[index] = value;
        }

        /// <summary>
        /// Deletes an element at the given index by shifting elements left.
        /// The last element becomes 0.
        /// </summary>
        /// <param name="arr">Target array.</param>
        /// <param name="index">Zero-based index (0..arr.Length-1).</param>
        /// <remarks>O(n) time, O(1) space.</remarks>
        public static void DeleteFromArray(int[] arr, int index)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[arr.Length - 1] = 0; // Clear last slot
        }

        // ========= STRINGS =========

        /// <summary>
        /// Concatenates names using += with a space before each name, matching the lab style.
        /// </summary>
        /// <param name="names">Array of names.</param>
        /// <returns>All names joined with spaces.</returns>
        /// <remarks>O(n²) time due to string immutability.</remarks>
        public static string ConcatenateNamesNaive(string[] names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            string result = string.Empty;
            foreach (var name in names)
            {
                result += " " + name; 
            }

            // Trim leading space for a clean output
            return result.TrimStart();
        }

        /// <summary>
        /// Concatenates names efficiently using a StringBuilder with spaces.
        /// </summary>
        /// <param name="names">Array of names.</param>
        /// <returns>All names joined with spaces.</returns>
        /// <remarks>O(n) amortized time.</remarks>
             public static string ConcatenateNamesBuilder(string[] names)
        {
            if (names == null) throw new ArgumentNullException(nameof(names));

            var sb = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                sb.Append(" ").Append(names[i]); 
            }

            return sb.ToString().TrimStart();
        }

        /// <summary>
        /// Capitalizes each word in a name string.
        /// </summary>
        public static string CapitalizeEachName(string name)
        {
            if (name == null) return string.Empty;

            var parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                var p = parts[i];
                parts[i] = p.Length == 0 ? p : char.ToUpper(p[0]) + p.Substring(1).ToLower();
            }

            return string.Join(" ", parts);
        }

        // ========= LISTS =========

        /// <summary>
        /// Inserts a value into a List at the given index.
        /// </summary>
        /// <param name="list">Target list.</param>
        /// <param name="index">0..Count.</param>
        /// <param name="value">Value to insert.</param>
        /// <remarks>
        /// O(n) for middle inserts (array-backed shifts),
        /// amortized O(1) when adding to the end if capacity is available.
        /// </remarks>
        /// 
        // InsertIntoList inserts a value into a List at the given index.  With the time
        // complexity of O(n) for middle inserts (array-backed shifts), and amortized O(1)
        // when adding to the end if capacity is available. Trend noted is that inserts at
        // the start or middle of a large list take longer than inserts at the end.
        public static void InsertIntoList(List<int> list, int index, int value)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (index < 0 || index > list.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds.");

            list.Insert(index, value);
        }
    }
}
