using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    public class ComplexityTester
    {
        /// <summary> O(1) - Constant Time Complexity: a math method </summary>
        /// <param name="n"> the input size </param>
        /// <remarks> Method runs set operations despite n value. </remarks>
        public long RunConstantScenario(int n)
        {
            return (long) n * (n + 1) / 2;
        }

        /// <summary> O(n) - Linear Time Complexity: a method looping 1 to n adding them together </summary>
        /// <param name="n"> the input size </param>
        /// <remarks> Growing one at a time as n increases </remarks>
        public long RunLinearScenario(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        /// <summary> O(n^2) - Quadratic Time Complexity: a method looping 1 to n inside another loop 1 to n </summary>
        /// <param name="n"> the input size </param>
        /// <remarks> Growing by the square as n increases </remarks>
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
