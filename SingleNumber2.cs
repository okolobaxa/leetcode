using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace leetcode
{
    /// https://leetcode.com/problems/single-number-ii/
    public class SingleNumber2Problem
    {
        [Fact]
        public void SingleNumber2Test1()
        {
            var nums = new int[] { 2, 2, 3, 2 };

            var result = SingleNumber(nums);

            Assert.Equal(3, result);
        }

        [Fact]
        public void SingleNumber2Test2()
        {
            var nums = new int[] { 0, 1, 0, 1, 0, 1, 99 };

            var result = SingleNumber(nums);

            Assert.Equal(99, result);
        }

        [Fact]
        public void SingleNumber2Test3()
        {
            var nums = new int[] { 1 };

            var result = SingleNumber(nums);

            Assert.Equal(1, result);
        }
        
        [Fact]
        public void SingleNumber2Test4()
        {
            var nums = new int[] { -2, -2, -3, -2 };

            var result = SingleNumber(nums);

            Assert.Equal(-3, result);
        }

        public int SingleNumber(int[] nums)
        {
            var result = 0;

            for (int i = 0; i < 32; i++)
            {
                var mask = 1 << i;
                var count = 0;

                for (int j = 0; j < nums.Length; j++)
                {
                    if ((mask & nums[j]) != 0)
                    {
                        count++;
                    }
                }

                if (count % 3 > 0)
                {
                    result |= mask;
                }
            }

            return result;
        }
    }
}
