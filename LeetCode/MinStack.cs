// URL: https://leetcode.com/problems/min-stack/submissions/
using System.Collections;

namespace LeetCode;

public class MinStackProb
{
    [Fact]
    public void Test()
    {
        var input = "test";
        var expected = true;
        Assert.Equal(expected, Algo(input));
    }

    public bool Algo(string s)
    {
        return true;
    }

    public class MinStack
    {
        class Node
        {
            private readonly int _val;
            private readonly int _min;
            public Node? Prev { get; set; }

            public Node(int val, int min, Node prev)
            {
                _val = val;
                _min = min;
                Prev = prev;
            }

            public int GetValue() => _val;
            public int GetMin() => _min;
        }

        private Node? _top;

        public MinStack()
        {
        }

        public void Push(int val)
        {
            if (_top == null)
            {
                _top = new Node(val, val, _top);
            }
            else
            {
                _top = new Node(val, Math.Min(_top.GetMin(), val), _top);
            }
        }

        public void Pop()
        {
            _top = _top.Prev;
        }


        public int Top()
        {
            return _top.GetValue();
        }


        public int GetMin()
        {
            return _top.GetMin();
        }
    }
}