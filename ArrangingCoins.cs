using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;
using Xunit.Abstractions;

namespace leetcode
{
    /// https://leetcode.com/problems/arranging-coins/
    
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class ArrangingCoinsProblem
    {
        [Fact]
        public void ArrangingCoinsTest1()
        {
            var n = 5;

            var result = ArrangeCoins(n);

            Assert.Equal(2, result);
        }

        [Fact]
        public void ArrangingCoinsTest2()
        {
            var n = 8;

            var result = ArrangeCoins(n);

            Assert.Equal(3, result);
        }

        [Fact]
        public void ArrangingCoinsTest3()
        {
            var n = 1;

            var result = ArrangeCoins(n);

            Assert.Equal(1, result);
        }

        [Fact]
        public void ArrangingCoinsTest4()
        {
            var n = 2;

            var result = ArrangeCoins(n);

            Assert.Equal(1, result);
        }

        [Fact]
        public void ArrangingCoinsTest5()
        {
            var n = 6;

            var result = ArrangeCoins(n);

            Assert.Equal(3, result);
        }
        
        [Fact]
        public void ArrangingCoinsTest6()
        {
            var n = 1804289383;

            var result = ArrangeCoins(n);

            Assert.Equal(60070, result);
        }

        [Benchmark(Description = "Binary search O(logN)")]
        public void ArrangeCoinsBenchmark1()
        {
            var result = ArrangeCoins(2000);
        }

        [Benchmark(Description = "Default O(N)", Baseline = true)]
        public void ArrangeCoinsBenchmark2()
        {
            var result = ArrangeCoins2(2000);
        }

        [Benchmark(Description = "Math O(1)")]
        public void ArrangeCoinsBenchmark3()
        {
            var result = ArrangeCoins2(2000);
        }

        public int ArrangeCoins2(int n)
        {
            if (n < 3) return 1;

            var rows = 0;

            while (rows + 1 <= n)
            {
                rows++;
                n -= rows;
            }

            return rows;
        }

        public int ArrangeCoins3(int n)
        {
            return (int)(Math.Sqrt(2 * (long)n + 0.25) - 0.5);
        }

        public int ArrangeCoins(int n)
        {
            if (n < 3) return 1;

            long rows = 0;
            long currentLevel = 0;

            long left = 0;
            long right = n;

            while (left <= right)
            {
                rows = left + (right - left) / 2;
                currentLevel = rows * (rows + 1) / 2;

                if (currentLevel == n) return (int) rows;

                if (n < currentLevel)
                {
                    right = rows - 1;
                }
                else
                {
                    left = rows + 1;
                }
            }

            return (int)right;
        }

        public int ArrangeCoinsFast(int n)
        {
            if (n < 3) return 1;

            // if n > ~2000, O(logN) binary search works faster then O(1) math solution
            if (n < 2000)
            {
                return (int)(Math.Sqrt(2 * (long)n + 0.25) - 0.5);
            }

            long rows = 0;
            long currentLevel = 0;

            long left = 0;
            long right = n;

            while (left <= right)
            {
                rows = left + (right - left) / 2;
                currentLevel = rows * (rows + 1) / 2;

                if (currentLevel == n) return (int) rows;

                if (n < currentLevel)
                {
                    right = rows - 1;
                }
                else
                {
                    left = rows + 1;
                }
            }

            return (int)right;
        }
    }
}
