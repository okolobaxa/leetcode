using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/longest-common-prefix/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class LongestCommonPrefixProblem
    {
        [Fact]
        public void LongestCommonPrefixTest1()
        {
            var strings = new string[] { "flower", "flow", "flight" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("fl", result);
        }

        [Fact]
        public void LongestCommonPrefixTest2()
        {
            var strings = new string[] { "dog", "racecar", "car" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("", result);
        }

        [Fact]
        public void LongestCommonPrefixTest3()
        {
            var strings = new string[] { "dog" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("dog", result);
        }

        [Fact]
        public void LongestCommonPrefixTest4()
        {
            var strings = new string[] { "d" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("d", result);
        }

        [Fact]
        public void LongestCommonPrefixTest5()
        {
            var strings = new string[] { "dog", "", "car" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("", result);
        }

        [Fact]
        public void LongestCommonPrefixTest6()
        {
            var strings = new string[] { "", "", "" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("", result);
        }

        [Fact]
        public void LongestCommonPrefixTest7()
        {
            var strings = new string[] { "aa", "ab" };
            var result = LongestCommonPrefix(strings);

            Assert.Equal("a", result);
        }

        [Fact]
        public void RunBenchmark()
        {
            BenchmarkSwitcher.FromAssembly(typeof(LongestCommonPrefixProblem).Assembly).Run(Array.Empty<string>());
        }

        private string[] array = new string[] { "aa", "ab" };

        [Benchmark(Description = "Without spans")]
        public void LongestCommonPrefixBenchmark1()
        {
            var result = LongestCommonPrefixSlow(array);
        }

        [Benchmark(Description = "With spans")]
        public void LongestCommonPrefixBenchmark2()
        {
            var result = LongestCommonPrefix(array);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs[0].Length == 0) return string.Empty;

            var span = strs[0].AsSpan();

            var commonPrefix = string.Empty;

            for (int position = 1; position <= span.Length; position++)
            {
                var prefix = span.Slice(0, position);

                for (int stringIndex = 0; stringIndex < strs.Length; stringIndex++)
                {
                    if (!strs[stringIndex].AsSpan().StartsWith(prefix))
                    {
                        return commonPrefix;
                    }
                }

                commonPrefix += span[position - 1];
            }

            return commonPrefix;
        }

        public string LongestCommonPrefixSlow(string[] strs)
        {
            if (strs[0].Length == 0) return "";

            var confirmedPrefix = "";

            for (int c = 1; c <= strs[0].Length; c++)
            {
                var prefixToCheck = strs[0].Substring(0, c);

                for (int i = 0; i < strs.Length; i++)
                {
                    if (!strs[i].StartsWith(prefixToCheck))
                    {
                        return confirmedPrefix;
                    }
                }

                confirmedPrefix = prefixToCheck;
            }

            return confirmedPrefix;
        }
    }
}