using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/remove-element/
    public class RemoveElementProblem
    {
        [Fact]
        public void RemoveElementTest1()
        {
            var nums = new int[] { 3, 2, 2, 3 };

            var result = RemoveElement(nums, 3);

            Assert.Equal(new int[] { 2, 2, 3, 3 }, nums);
            Assert.Equal(2, result);
        }

        [Fact]
        public void RemoveElementTest2()
        {
            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };

            var result = RemoveElement(nums, 2);

            Assert.Equal(new int[] { 0, 1, 4, 0, 3, 2, 2, 2 }, nums);
            Assert.Equal(5, result);
        }

        public int RemoveElement(int[] nums, int val)
        {
            int lastCorrectPosition = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[lastCorrectPosition] = nums[i];
                    lastCorrectPosition++;
                }
            }

            return lastCorrectPosition;
        }
    }
}
