using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/sum-of-left-leaves/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class SumOfLeftLeavesProblem
    {
        [Fact]
        public void SumOfLeftLeavesTest1()
        {
            var treeRoot = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7)
                )
            );

            var result = SumOfLeftLeaves(treeRoot);

            Assert.Equal(24, result);
        }

        [Fact]
        public void SumOfLeftLeavesTest2()
        {
            var treeRoot = new TreeNode(1);

            var result = SumOfLeftLeaves(treeRoot);

            Assert.Equal(0, result);
        }
        
        [Fact]
        public void SumOfLeftLeavesTest3()
        {
            var treeRoot = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5,
                        new TreeNode(6),
                        new TreeNode(7))),
                new TreeNode(3,
                    new TreeNode(8),
                    new TreeNode(9)
                )
            );

            var result = SumOfLeftLeaves(treeRoot);

            Assert.Equal(18, result);
        }
        
        [Fact]
        public void SumOfLeftLeavesTest4()
        {
            var treeRoot = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(3,
                        new TreeNode(4,
                            new TreeNode(5,
                                new TreeNode(6,
                                    new TreeNode(7,
                                        new TreeNode(8,
                                            new TreeNode(9
                ))))))))
            );

            var result = SumOfLeftLeaves(treeRoot);

            Assert.Equal(9, result);
        }

        TreeNode treeRootTest = new TreeNode(3,
                new TreeNode(9),
                new TreeNode(20,
                    new TreeNode(15),
                    new TreeNode(7)
                )
            );

        [Benchmark]
        public void LongestCommonPrefixBenchmark1()
        {
            var result = SumOfLeftLeaves(treeRootTest);
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            if (IsLeaf(root)) return 0;

            var result =  Travers(root);

            return result;
        }

        private bool IsLeaf(TreeNode root)
        {
            return root.left == null && root.right == null;
        }

        public int Travers(TreeNode root)
        {
            if (root == null)
                return 0;
            
            var result = Travers(root.left) + Travers(root.right);
   
            if (root.left != null && IsLeaf(root.left))
            {
                result += root.left.val;
            }

            return result;
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