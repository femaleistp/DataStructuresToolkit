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

        /// <summary>
        /// Sorts an array of integers in ascending order using the Merge Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        /// <remarks>Complexity time O(n log n) and space O(n)</remarks>
        public static void MergeSort(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length <= 1)
            {
                return;
            }
            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);
            MergeSort(left);
            MergeSort(right);
            Merge(arr, left, right);
        }

        /// <summary>
        /// Helper method to merge two sorted arrays into a single sorted array.
        /// </summary>
        /// <param name="arr">The target array to hold the merged result.</param>
        /// <param name="left">The left sorted array.</param>
        /// <param name="right">The right sorted array.</param>
        /// <remarks>complexity time O(n) and space O(n)</remarks>
        public static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k++] = left[i++];
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }

            while (j < right.Length)
            {
                arr[k++] = right[j++];
            }
        }
    }
}
