using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/remove-linked-list-elements/

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net50)]
    public class RemoveLinkedListElementsProblem
    {
        [Fact]
        public void RemoveLinkedListElements1()
        {
            var head = new ListNode(1,
                new ListNode(2,
                    new ListNode(6,
                        new ListNode(3,
                            new ListNode(4,
                                new ListNode(5,
                                    new ListNode(6)
            ))))));

            var result = RemoveElements(head, 6);

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, Flatten(result));
        }

        [Fact]
        public void RemoveLinkedListElementsTest2()
        {
            var result = RemoveElements(null, 1);

            Assert.Equal(new int[0], Flatten(result));
        }

        [Fact]
        public void RemoveLinkedListElements3()
        {
            var head = new ListNode(7,
                new ListNode(7,
                    new ListNode(7,
                        new ListNode(7
            ))));

            var result = RemoveElements(head, 7);

            Assert.Equal(new int[0], Flatten(result));
        }

        [Fact]
        public void RemoveLinkedListElements4()
        {
            var head = new ListNode(6,
                new ListNode(2,
                    new ListNode(6,
                        new ListNode(3,
                            new ListNode(4,
                                new ListNode(5,
                                    new ListNode(6)
            ))))));

            var result = RemoveElements(head, 6);

            Assert.Equal(new int[] { 2, 3, 4, 5 }, Flatten(result));
        }

        private int[] Flatten(ListNode head)
        {
            var result = new List<int>();

            while (head != null)
            {
                result.Add(head.val);

                head = head.next;
            }

            return result.ToArray();
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            var start = new ListNode(0, head);
            
            ListNode prev = start, current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    prev.next = current.next;
                } 
                else
                {
                    prev = current;
                }

                current = current.next;
            }

            return start.next;
        }

        public void Travers(ListNode head, int val)
        {
            ListNode prev = null, current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    current = current.next;
                } else
                {
                    prev = current;
                }
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}