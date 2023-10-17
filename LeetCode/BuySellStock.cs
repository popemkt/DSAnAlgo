// URL: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/ 

using System.Diagnostics.CodeAnalysis;

namespace LeetCode;

public class BuySellStockLC
{
    [Fact]
    public void Test()
    {
        var input = new int[] { 1,2 };

        var expected = 1;
        Assert.Equal(expected, Naive(input));
        Assert.Equal(expected, UseMaxStack(input));
        Assert.Equal(expected, WithoutMaxStackIsFine(input));
    }

    //Naive approach, took too long
    public int Naive(int[] s)
    {
        var max = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                max = Math.Max(s[j] - s[i], max);
            } 
        }

        return max;
    }
    public int WithoutMaxStackIsFine(int[] s)
    {
        var leftMin = s[0];
        var max = 0;
        //Move the cursor to the end, keeping track of the min of the left of the cursor, and max of the right of the cursor
        //Max profit should be rightMax - leftMin at a given cursor position
        for (int i = 1; i < s.Length; i++)
        {
            leftMin = Math.Min(leftMin, s[i - 1]);
            max = Math.Max(max, s[i] - leftMin);
        }

        return max;
    } 
    public int UseMaxStack(int[] s)
    {
        var maxStack = MaxStack.FromArray(s.Reverse().ToArray());
        var leftMin = s[0];
        int rightMax;
        var max = 0;
        //Move the cursor to the end, keeping track of the min of the left of the cursor, and max of the right of the cursor
        //Max profit should be rightMax - leftMin at a given cursor position
        for (int i = 0; i < s.Length - 1; i++)
        {
            maxStack.Pop();
            rightMax = maxStack.CurrentMax();
            leftMin = Math.Min(leftMin, s[i]); 
            max = Math.Max(max, rightMax - leftMin);
        }

        return max;
    }

    class MaxStack
    {
        private Node _head;
        class Node
        {
            public Node Prev { get; set; }
            public int Val { get; set; }
            public int CurrentMax { get; set; }
        }
        
        public static MaxStack FromArray(int[] array)
        {
            var stack = new MaxStack();
            for (int i = 0; i < array.Length; i++)
            {
                stack.Insert(array[i]);
            }

            return stack;
        }

        public int CurrentMax() => _head.CurrentMax;
        public void Insert(int val)
        {
            _head = new Node()
            {
                Val = val,
                Prev = _head,
                CurrentMax = _head is null ? val : Math.Max(val, _head.CurrentMax),
            };
        }

        public void Pop() => _head = _head.Prev;
    }
}