using System.Text.RegularExpressions;

namespace LeetCode;

public class Palindrome
{
    [Fact]
    public void Test1()
    {
        Assert.True(IsPalindrome1("A man, a plan, a canal: Panama"));
        Assert.True(IsPalindrome2("A man, a plan, a canal: Panama"));
    }
    
    public bool IsPalindrome1(string s)
    {
        s = s.ToLowerInvariant();

        s = new string(s.Where(c => char.IsLetterOrDigit(c)).ToArray());

        if (string.IsNullOrEmpty(s)) return true;
        
        for (int i = 0; i <= s.Length / 2; i++)
        {
            if (s[i] == s[^(i+1)]) continue;

            return false;
        }

        return true;
    }

    public bool IsPalindrome2(string s)
    {
        s = s.ToLowerInvariant();

        s = new string(s.Where(c => char.IsLetterOrDigit(c)).ToArray());

        if (string.IsNullOrEmpty(s)) return true;

        var reversedS = new string(s.Reverse().ToArray());

        return s.Equals(reversedS);
    }
}