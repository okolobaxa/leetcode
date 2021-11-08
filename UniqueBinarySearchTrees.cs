using System.Collections.Generic;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/unique-binary-search-trees/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class UniqueBinarySearchTreesProblem
    {
        [Fact]
        public void UniqueBinarySearchTreesTest1()
        {
            var result = NumTrees(3);

            Assert.Equal(5, result);
        }

        [Fact]
        public void UniqueBinarySearchTreesTest2()
        {
            var result = NumTrees(1);

            Assert.Equal(1, result);
        }

        [Fact]
        public void UniqueBinarySearchTreesTest3()
        {
            var result = NumTrees(4);

            Assert.Equal(14, result);
        }

        [Fact]
        public void UniqueBinarySearchTreesTest4()
        {
            var result = NumTrees(19);

            Assert.Equal(1767263190, result);
        }

        public int NumTrees(int n)
        {
            //Catalan number https://en.wikipedia.org/wiki/Catalan_number
            //C(n) = (2n)!/(n!(n+1)!)

            var number = Factorial(2 * n) / (Factorial(n) * (Factorial(n + 1)));

            return (int)number;
        }

        Dictionary<int, BigInteger> fibCache = new();

        private BigInteger Factorial(int n)
        {
            if (fibCache.ContainsKey(n))
            {
                return fibCache[n];
            }

            if (n == 1)
            {
                return 1;
            }
            else
            {
                var fact = n * Factorial(n - 1);

                fibCache.Add(n, fact);

                return fact;
            }
        }
    }
}
