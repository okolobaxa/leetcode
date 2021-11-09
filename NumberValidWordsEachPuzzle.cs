using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/number-of-valid-words-for-each-puzzle/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class NumberValidWordsEachPuzzleProblem
    {
        [Fact]
        public void NumberValidWordsEachPuzzleTest1()
        {
            var words = new string[] { "aaaa", "asas", "able", "ability", "actt", "actor", "access" };
            var puzzles = new string[] { "aboveyz", "abrodyz", "abslute", "absoryz", "actresz", "gaswxyz" };

            var result = FindNumOfValidWords(words, puzzles);

            Assert.Equal(new List<int> { 1, 1, 3, 2, 4, 0 }, result);
        }

        [Fact]
        public void NumberValidWordsEachPuzzleTest2()
        {
            var words = new string[] { "apple", "pleas", "please" };
            var puzzles = new string[] { "aelwxyz", "aelpxyz", "aelpsxy", "saelpxy", "xaelpsy" };

            var result = FindNumOfValidWords(words, puzzles);

            Assert.Equal(new List<int> { 0, 1, 3, 2, 0 }, result);
        }

        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var result = new List<int>(puzzles.Length);

            var map = new Dictionary<int, int>();

            foreach (var word in words)
            {
                var mask = GetMask(word);

                if (!map.ContainsKey(mask))
                {
                    map.Add(mask, 0);
                }

                map[mask]++;
            }

            foreach (var puzzle in puzzles)
            {
                var span = puzzle.AsSpan();

                int firstSymbolMask = GetMask(span.Slice(0, 1));
                int count = map.GetValueOrDefault(firstSymbolMask, 0);

                var mask = GetMask(span.Slice(1));

                for (var submask = mask; submask > 0; submask = ((submask - 1) & mask))
                {
                    count += map.GetValueOrDefault(submask | firstSymbolMask, 0);
                }

                result.Add(count);
            }

            return result;
        }

        private int GetMask(ReadOnlySpan<char> readOnlySpan)
        {
            var mask = 0;

            foreach (var c in readOnlySpan)
            {
                mask |= 1 << (c - 'a');
            }

            return mask;
        }
    }
}