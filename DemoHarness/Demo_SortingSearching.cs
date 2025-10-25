using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using DataStructuresToolkit;

namespace DemoHarness
{
    /// <summary>
    /// Demo class for Sorting and Searching Helpers.
    /// </summary>
    public class Demo_SortingSearching
    {
        /// <summary>
        /// Entry point for the Sorting and Searching demo.
        /// </summary>
        /// <param name="args">Command-line arguments (not used)</param>
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demo: Sorting and Searching Helpers ===\n");

            // Test sizes
            int[] sizes = { 100, 1000, 10000 };

            Console.WriteLine($"{"Array Size",-12}{"BubbleSort (ms)",-20}{"MergeSort (ms)",-20}{"LinearSearch (ms)",-22}{"BinarySearch (ms)"}");

            foreach (int size in sizes)
            {
                // Generate random array
                int[] arr1 = GenerateRandomArray(size);
                int[] arr2 = (int[])arr1.Clone();

                // BubbleSort timing
                var sw = Stopwatch.StartNew();
                SortingSearchingHelpers.BubbleSort(arr1);
                sw.Stop();
                long bubbleSortTime = sw.ElapsedMilliseconds;

                // MergeSort timing
                sw.Restart();
                SortingSearchingHelpers.MergeSort(arr2);
                sw.Stop();
                long mergeSortTime = sw.ElapsedMilliseconds;

                // Prepare sorted array for search
                int[] sorted = (int[])arr2.Clone();
                int target = sorted[size / 2]; // Target for searching

                // LinearSearch timing
                sw.Restart();
                SortingSearchingHelpers.LinearSearch(sorted, target);
                sw.Stop();
                long linearSearchTime = sw.ElapsedMilliseconds;

                // BinarySearch timing
                sw.Restart();
                SortingSearchingHelpers.BinarySearch(sorted, target);
                sw.Stop();
                long binarySearchTime = sw.ElapsedMilliseconds;

                // Output results
                Console.WriteLine($"{size,-12}{bubbleSortTime,-20}{mergeSortTime,-20}{linearSearchTime,-22}{binarySearchTime}");
            }
        }

        private static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(0, size * 10);
            }
            return arr;
        }
    }
}
