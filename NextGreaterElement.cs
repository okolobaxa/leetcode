using System.Collections.Generic;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/next-greater-element-i/
    public class NextGreaterElementProblem
    {   
        [Fact]
        public void NextGreaterElementTest1()
        {
            var nums1 = new int[] { 4, 1, 2 };
            var nums2 = new int[] { 1, 3, 4, 2 };

            var result = NextGreaterElement(nums1, nums2);

            Assert.Equal(new int[] { -1, 3, -1 }, result);
        }

        [Fact]
        public void NextGreaterElementTest2()
        {
            var nums1 = new int[] { 2, 4 };
            var nums2 = new int[] { 1, 2, 3, 4 };

            var result = NextGreaterElement(nums1, nums2);

            Assert.Equal(new int[] { 3, -1 }, result);
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var stack = new Stack<int>();
            var dict = new Dictionary<int, int>();

            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                while (stack.TryPeek(out var top) && nums2[i] >= nums2[top]) 
                    stack.Pop();
                
                dict.Add(nums2[i], stack.TryPeek(out var nextGreatPosition) ? nextGreatPosition : -1);
                stack.Push(i);
            }

            var result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                var pos = dict[nums1[i]];
                result[i] = pos == -1 ? -1 : nums2[pos];
            }

            return result;
        }
    }
}