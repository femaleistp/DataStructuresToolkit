using System.Diagnostics;

namespace DataStructuresToolkit.Tests
{
    public class ComplexityTester_Tests
    {
        private readonly ComplexityTester _ct = new ComplexityTester();

        [Fact]
        public void RunConstantScenario()
        {
            int[] testSizes = { 10, 1000, 100000 };
            
            foreach (int n in testSizes)
            {
                var sw = Stopwatch.StartNew();
                long result = _ct.RunConstantScenario(n);
                sw.Stop();

                Console.WriteLine($"O(1) n={n}: {sw.ElapsedMilliseconds} ms, result={result}");
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void RunLinearScenario()
        {
            int[] testSizes = { 10, 1000, 100000 };

            foreach (int n in testSizes)
            {
                var sw = Stopwatch.StartNew();
                long result = _ct.RunLinearScenario(n);
                sw.Stop();

                Console.WriteLine($"O(n) n={n}: {sw.ElapsedMilliseconds} ms, result={result}");
                Assert.True(result > 0);
            }
        }

        [Fact]
        public void RunQuadraticScenario()
        {
            int[] testSizes = { 10, 1000, 100000 };

            foreach (int n in testSizes)
            {
                var sw = Stopwatch.StartNew();
                long result = _ct.RunQuadraticScenario(n);
                sw.Stop();

                Console.WriteLine($"O(n^2) n={n}: {sw.ElapsedMilliseconds} ms, result={result}");
                Assert.True(result > 0);
            }
        }
    }
}
