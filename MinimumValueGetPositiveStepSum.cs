using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
    public class MinimumValueGetPositiveStepSumProblem
    {
        [Fact]
        public void MinimumValueGetPositiveStepSumTest1()
        {
            var nums = new int[] { -3, 2, -3, 4, 2 };

            var result = MinStartValue(nums);

            Assert.Equal(5, result);
        }

        [Fact]
        public void MinimumValueGetPositiveStepSumTest2()
        {
            var nums = new int[] { 1, 2 };

            var result = MinStartValue(nums);

            Assert.Equal(1, result);
        }

        [Fact]
        public void MinimumValueGetPositiveStepSumTest3()
        {
            var nums = new int[] { 1, -2, -3 };

            var result = MinStartValue(nums);

            Assert.Equal(5, result);
        }

        [Fact]
        public void MinimumValueGetPositiveStepSumTest4()
        {
            var nums = new int[] { 1, -2 };

            var result = MinStartValue(nums);

            Assert.Equal(2, result);
        }

        public int MinStartValue(int[] nums)
        {
            var start = 1;
            var sum = start;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < 1)
                {
                    var add = 1 - sum;
                    sum += add;
                    start += add;
                }
            }

            return start;
        }
    }
}
