using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/sum-root-to-leaf-numbers/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class SumRootToLeafNumbersProblem
    {
        [Fact]
        public void SumRootToLeafNumbers1()
        {
            var treeRoot = new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3)
            );

            var result = SumNumbers(treeRoot);

            Assert.Equal(25, result);
        }

        [Fact]
        public void SumRootToLeafNumbersTest2()
        {
            var treeRoot = new TreeNode(4,
                new TreeNode(9,
                    new TreeNode(5),
                    new TreeNode(1)
                ),
                new TreeNode(0)
            );

            var result = SumNumbers(treeRoot);

            Assert.Equal(1026, result);
        }

        TreeNode treeRootTest = new TreeNode(4,
                new TreeNode(9,
                    new TreeNode(5),
                    new TreeNode(1)
                ),
                new TreeNode(0)
            );

        [Benchmark]
        public void LongestCommonPrefixBenchmark1()
        {
            var result = SumNumbers(treeRootTest);
        }

        public int SumNumbers(TreeNode root)
        {
            return Travers(root, 0);
        }

        public int Travers(TreeNode root, int currentValue)
        {
            if (root == null)
                return 0;

            currentValue = 10 * currentValue + root.val;

            if (root.left == null && root.right == null)
            {
                return currentValue;
            }

            return Travers(root.left, currentValue) + Travers(root.right, currentValue);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}