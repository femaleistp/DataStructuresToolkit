using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class ArrayStringListHelpers_Tests_
    {
        [Fact]
        public void InsertIntoArray_ShiftsRight()
        {
            // Arrange
            int[] arr = { 1001, 2001, 3001, 4001, 5001 };
            // Act
            ArrayStringListHelpers.InsertIntoArray(arr, 2, 3000);
            // Assert
            Assert.Equal(new[] { 1001, 2001, 3000, 3001, 4001 }, arr);
        }

        [Fact]
        public void DeleteFromArray_ShiftsLeft_AndClearsTail()
        {
            // Arrange
            int[] arr = { 1001, 2001, 3001, 4001, 5001 };
            // Act
            ArrayStringListHelpers.DeleteFromArray(arr, 2);
            // Assert
            Assert.Equal(new[] { 1001, 2001, 4001, 5001, 0 }, arr);
        }

        [Fact]
        public void InsertIntoList_Middle()
        {
            // Arrange
            var list = new List<int> { 1001, 2001, 3001, 4001, 5001 };
            // Act
            ArrayStringListHelpers.InsertIntoList(list, 2, 3000);
            // Assert
            Assert.Equal(new List<int> { 1001, 2001, 3000, 3001, 4001, 5001 }, list);
        }

        [Fact]
        public void Concat_SameResult_NaiveVsBuilder_PrintTicks()
        {
            // Arrange
            int n = 10000;
            var names = new string[n];
            for (int i = 0; i < n; i++)
            {
                names[i] = "bo";
            }

            var sw = Stopwatch.StartNew();
            // Act - Naive
            var s1 = ArrayStringListHelpers.ConcatenateNamesNaive(names);
            sw.Stop();
            Console.WriteLine($"Naive += ticks: {sw.ElapsedTicks}");

            sw.Reset();
            sw.Start();
            // Act - Builder
            var s2 = ArrayStringListHelpers.ConcatenateNamesBuilder(names);
            sw.Stop();
            Console.WriteLine($"StringBuilder ticks: {sw.ElapsedTicks}");

            // Assert
            Assert.Equal(s1.Length, s2.Length);
        }

        [Fact]
        public void CapitalizeEachName_MatchesLabStyle()
        {
            // Arrange
            var s = "after inserting eli in the middle: max mia leo";
            // Act
            var cap = ArrayStringListHelpers.CapitalizeEachName(s);
            // Assert
            Assert.Equal("After Inserting Eli In The Middle: Max Mia Leo", cap);
        }
    }
}
