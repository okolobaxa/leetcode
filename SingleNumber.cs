using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace leetcode
{
    /// https://leetcode.com/problems/single-number/
    public class SingleNumberProblem
    {
        [Fact]
        public void SingleNumberTest1()
        {
            var nums = new int[] { 2, 2, 1 };

            var result = SingleNumber(nums);

            Assert.Equal(1, result);
        }

        [Fact]
        public void SingleNumberTest2()
        {
            var nums = new int[] { 4, 1, 2, 1, 2 };

            var result = SingleNumber(nums);

            Assert.Equal(4, result);
        }

        [Fact]
        public void SingleNumberTest3()
        {
            var nums = new int[] { 1 };

            var result = SingleNumber(nums);

            Assert.Equal(1, result);
        }

        public int SingleNumber(int[] nums)
        {
            var result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }
    }
}
