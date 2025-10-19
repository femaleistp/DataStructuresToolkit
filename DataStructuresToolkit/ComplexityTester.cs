using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class ComplexityTester
    {
        /// <summary>
        /// O(1) - Constant Time Complexity: a method calculating the sum of 1 to n using the formula n(n+1)/2
        /// </summary>
        /// <param name="n"> the input size </param>
        /// <returns> the sum from 1 to n </returns>
        /// <remarks> complexity time O(1) and space O(1) </remarks>
        public long RunConstantScenario(int n)
        {
            return (long) n * (n + 1) / 2;
        }

        /// <summary>
        /// O(n) - Linear Time Complexity: a method looping from 1 to n and summing the values
        /// </summary>
        /// <param name="n"> the input size </param>
        /// <returns> the sum from 1 to n </returns>
        /// <remarks>complexity time O(n) and space O(1)</remarks>
        public long RunLinearScenario(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        /// <summary>
        /// O(n^2) - Quadratic Time Complexity: a method with nested loops from 1 to n, summing the product of the indices
        /// </summary>
        /// <param name="n"> the input size </param>
        /// <returns> the sum of products of indices </returns>
        /// <remarks>complexity time O(n^2) and space O(1)</remarks>
        public long RunQuadraticScenario(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sum += i * j;
                }
            }
            return sum;
        }
    }
}
