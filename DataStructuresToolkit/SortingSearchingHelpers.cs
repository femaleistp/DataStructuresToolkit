using System;
using System.Diagnostics;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Helper methods for sorting and searching algorithms.
    /// </summary>
    /// <remarks>Contains two searching algorithms (Linear, Binary) 
    /// and two sorting algorithms (Bubble, Merge). Each method 
    /// includes XML documentation for clarity.</remarks>
    public static class SortingSearchingHelpers
    {

        /// <summary>
        /// Sorts an array of integers in ascending order using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        /// <remarks>complexity time O(n^2) and space O(1)</remarks>
        static void BubbleSort(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
