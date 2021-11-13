using System.Collections.Generic;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/daily-temperatures/
    public class DailyTemperaturesProblem
    {
        [Fact]
        public void DailyTemperaturesTest1()
        {
            var nums = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

            var result = DailyTemperatures(nums);

            Assert.Equal(new int[] { 1, 1, 4, 2, 1, 1, 0, 0 }, result);
        }

        [Fact]
        public void DailyTemperaturesTest2()
        {
            var nums = new int[] { 30, 40, 50, 60 };

            var result = DailyTemperatures(nums);

            Assert.Equal(new int[] { 1, 1, 1, 0 }, result);
        }

        [Fact]
        public void DailyTemperaturesTest3()
        {
            var nums = new int[] { 30, 60, 90 };

            var result = DailyTemperatures(nums);

            Assert.Equal(new int[] { 1, 1, 0 }, result);
        }

        [Fact]
        public void DailyTemperaturesTest4()
        {
            var nums = new int[] { 90, 60, 30 };

            var result = DailyTemperatures(nums);

            Assert.Equal(new int[] { 0, 0, 0 }, result);
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            var stack = new Stack<int>();

            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while(stack.TryPeek(out var top) && temperatures[top] <= temperatures[i])
                {
                    stack.Pop();
                }

                result[i] = !stack.TryPeek(out var top1) ? 0 : top1 - i;
                stack.Push(i);
            }

            return result;
        }
    }
}
