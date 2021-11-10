using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    public class BestTimeBuySellStock2Problem
    {
        [Fact]
        public void BestTimeBuySellStock2Test1()
        {
            var nums = new int[] { 7, 1, 5, 3, 6, 4 };

            var result = MaxProfit(nums);

            Assert.Equal(7, result);
        }

        [Fact]
        public void BestTimeBuySellStock2Test2()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };

            var result = MaxProfit(nums);

            Assert.Equal(4, result);
        }

        [Fact]
        public void BestTimeBuySellStock2Test3()
        {
            var nums = new int[] { 7, 6, 4, 3, 1 };

            var result = MaxProfit(nums);

            Assert.Equal(0, result);
        }

        public int MaxProfit(int[] prices)
        {
            var profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                var diff = prices[i] - prices[i - 1];

                if (diff > 0)
                {
                    profit += diff;
                }
            }

            return profit;
        }
    }
}
