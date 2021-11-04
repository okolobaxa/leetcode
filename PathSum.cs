using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/path-sum/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class PathSumProblem
    {
        [Fact]
        public void PathSumTest1()
        {
            var target = 22;
            var treeRoot = new TreeNode(5,
                new TreeNode(4,
                    new TreeNode(11,
                        new TreeNode(7),
                        new TreeNode(2))
                    ),
                new TreeNode(8,
                    new TreeNode(13),
                    new TreeNode(4, new TreeNode(1))
                ));

            var result = HasPathSum(treeRoot, target);

            Assert.Equal(true, result);
        }

        [Fact]
        public void PathSumTest2()
        {
            var target = 5;
            var treeRoot = new TreeNode(1,
                new TreeNode(2),
                new TreeNode(3)
            );

            var result = HasPathSum(treeRoot, target);

            Assert.Equal(false, result);
        }

        [Fact]
        public void PathSumTest3()
        {
            var target = 0;
            var treeRoot = new TreeNode(1,
                new TreeNode(2)
            );

            var result = HasPathSum(treeRoot, target);

            Assert.Equal(false, result);
        }

        [Fact]
        public void PathSumTest4()
        {
            var target = 0;
            var treeRoot = new TreeNode(0);

            var result = HasPathSum(treeRoot, target);

            Assert.Equal(true, result);
        }

        [Fact]
        public void PathSumTest5()
        {
            var target = 0;
            var treeRoot = new TreeNode(0,
                new TreeNode(0),
                new TreeNode(0)
            );

            var result = HasPathSum(treeRoot, target);

            Assert.Equal(true, result);
        }

        int targetTest = 22;
        TreeNode treeRootTest = new TreeNode(5,
            new TreeNode(4,
                new TreeNode(11,
                    new TreeNode(7),
                    new TreeNode(2))
                ),
            new TreeNode(8,
                new TreeNode(13),
                new TreeNode(4, new TreeNode(1))
            ));

        [Benchmark]
        public void LongestCommonPrefixBenchmark1()
        {
            var result = HasPathSum(treeRootTest, targetTest);
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return Travers(root, 0, targetSum);
        }

        public bool Travers(TreeNode root, int currentSum, int targetSum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null)
            {
                return currentSum + root.val == targetSum;
            }

            return Travers(root.left, currentSum + root.val, targetSum)
                        || Travers(root.right, currentSum + root.val, targetSum);
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