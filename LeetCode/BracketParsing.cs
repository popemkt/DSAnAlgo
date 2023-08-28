// URL: https://leetcode.com/problems/valid-parentheses/ 

using System.Collections;

namespace LeetCode;

public class BracketParsing
{
    [Fact]
    public void Test()
    {
        var input = "{}";
        var expected = true;
        Assert.Equal(expected, Algo(input));
    }
    
    public bool Algo(string s)
    {
        Stack stack = new Stack();
        List<char> openChars = new() { '(', '{', '[' };
        List<char> closingChars = new() { ')', '}', ']' };

        foreach (var c in s)
        {
            if (openChars.Contains(c))
                stack.Push(openChars.IndexOf(c));

            if (closingChars.Contains(c))
            {
                if (stack.Count == 0) return false;

                if ((int)stack.Peek() == closingChars.IndexOf(c))
                {
                    stack.Pop();
                    continue;
                }

                return false;
            }
        }
        return stack.Count == 0;
    }
}