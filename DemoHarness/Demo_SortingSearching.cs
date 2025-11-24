using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using DataStructuresToolkit;
using DataStructuresToolkit.SortingSearching;

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

            Console.WriteLine($"{"Array Size",-12}{"BubbleSort (µs)",-20}{"MergeSort (µs)",-20}{"LinearSearch (µs)",-22}{"BinarySearch (µs)"}");

            // Warm up the methods once to avoid JIT overhead on the first run
            SortingSearchingHelpers.BubbleSort(new int[] { 3, 1, 2 });
            SortingSearchingHelpers.MergeSort(new int[] { 3, 1, 2 });
            SortingSearchingHelpers.LinearSearch(new int[] { 1, 2, 3 }, 2);
            SortingSearchingHelpers.BinarySearch(new int[] { 1, 2, 3 }, 2);


            foreach (int size in sizes)
            {
                // Generate random array
                int[] arr1 = GenerateRandomArray(size);
                int[] arr2 = (int[])arr1.Clone();

                // BubbleSort timing
                var sw = Stopwatch.StartNew();
                SortingSearchingHelpers.BubbleSort(arr1);
                sw.Stop();
                double bubbleSortMicro = sw.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);

                // MergeSort timing
                sw.Restart();
                SortingSearchingHelpers.MergeSort(arr2);
                sw.Stop();
                double mergeSortMicro = sw.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);

                // Prepare sorted array for search
                int[] sorted = (int[])arr2.Clone();
                int target = sorted[size / 2]; // Target for searching

                // LinearSearch timing
                sw.Restart();
                SortingSearchingHelpers.LinearSearch(sorted, target);
                sw.Stop();
                double linearSearchMicro = sw.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);

                // BinarySearch timing
                sw.Restart();
                SortingSearchingHelpers.BinarySearch(sorted, target);
                sw.Stop();
                double binarySearchMicro = sw.ElapsedTicks * (1_000_000.0 / Stopwatch.Frequency);

                // Output results
                Console.WriteLine($"{size,-12}{bubbleSortMicro,-20:F0}{mergeSortMicro,-20:F0}{linearSearchMicro,-22:F1}{binarySearchMicro:F1}");

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

// Console output (timing results):
// === Demo: Sorting and Searching Helpers ===
//
// Array Size   BubbleSort (µs)   MergeSort (µs)   LinearSearch (µs)   BinarySearch (µs)
// 100          74                19               0.6                 0.2
// 1000         1402              184              5.2                 0.2
// 10000        142629            2828             53.0                0.3
