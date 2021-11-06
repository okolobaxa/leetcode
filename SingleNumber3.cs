using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace leetcode
{
    /// https://leetcode.com/problems/single-number-iii/
    public class SingleNumber3Problem
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SingleNumber3Problem(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void SingleNumber3Test1()
        {
            var nums = new int[] { 1, 2, 1, 3, 2, 5 };

            var result = SingleNumber(nums);

            Assert.Equal(new int[] { 3, 5 }, result);
        }

        [Fact]
        public void SingleNumber3Test2()
        {
            var nums = new int[] { -1, 0 };

            var result = SingleNumber(nums);

            Assert.Equal(new int[] { -1, 0 }, result);
        }

        [Fact]
        public void SingleNumber3Test3()
        {
            var nums = new int[] { 0, 1 };

            var result = SingleNumber(nums);

            Assert.Equal(new int[] { 1, 0 }, result);
        }

        [Fact]
        public void SingleNumber3Test4()
        {
            var nums = new int[] { 2, 1, 2, 3, 4, 1 };

            var result = SingleNumber(nums);

            Assert.Equal(new int[] { 3, 4 }, result);
        }

        public int[] SingleNumber2(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            return dict
                .Where(x => x.Value == 1)
                .Select(x => x.Key)
                .ToArray();
        }

        public int[] SingleNumber(int[] nums)
        {
            int a = 0, b = 0;

            var aXORb = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                aXORb ^= nums[i];
            }

            var mostRightDifferentBit = aXORb & -aXORb;

            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & mostRightDifferentBit) > 0)
                {
                    a ^= nums[i];
                }
            }

            b = aXORb ^ a;

            return new int[] { a, b };
        }
    }
}
