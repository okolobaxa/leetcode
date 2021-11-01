using System.Collections.Generic;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/two-sum/
    public class TwoSumProblem
    {
        [Fact]
        public void TwoSumTest1()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;

            var result = TwoSum2(nums, target);

            Assert.Equal(new int[] { 0, 1 }, result);
        }

        [Fact]
        public void TwoSumTest2()
        {
            var nums = new int[] { 3, 2, 4 };
            var target = 6;

            var result = TwoSum2(nums, target);

            Assert.Equal(new int[] { 1, 2 }, result);
        }

        [Fact]
        public void TwoSumTest3()
        {
            var nums = new int[] { 3, 3 };
            var target = 6;

            var result = TwoSum2(nums, target);

            Assert.Equal(new int[] { 0, 1 }, result);
        }

        [Fact]
        public void TwoSumTest4()
        {
            var nums = new int[] { 2, 5, 5, 11 };
            var target = 10;

            var result = TwoSum2(nums, target);

            Assert.Equal(new int[] { 1, 2 }, result);
        }

        [Fact]
        public void TwoSumTest5()
        {
            var nums = new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 };
            var target = 11;

            var result = TwoSum2(nums, target);

            Assert.Equal(new int[] { 5, 11 }, result);
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (map.ContainsKey(diff))
                {
                    return new[] { map[diff], i };
                }
                else
                {
                    map.TryAdd(nums[i], i);
                }
            }

            return null;
        }
    }
}
