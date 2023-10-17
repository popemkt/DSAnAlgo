// URL: https://leetcode.com/problems/longest-substring-without-repeating-characters/ 

namespace LeetCode;

public class LongestNonRepeatedSubString
{
    [Fact]
    public void Test()
    {
        var input = "dvdf";
        var expected = 3;
        Assert.Equal(expected, Algo(input));
    }

    public int Algo(string s)
    {
        if (s.Length == 0) return 0;
        if (s.Length == 1) return 1;
        var firstPointer = 0;
        var secondPointer = 1;
        HashSet<char> chars = new HashSet<char>();
        var maxLength = 1;
        while (secondPointer < s.Length)
        {
            chars.Add(s[firstPointer]);
            if (firstPointer == secondPointer)
            {
                secondPointer++;
                continue;
            }
            if (chars.Contains(s[secondPointer]))
            {
                chars.Remove(s[firstPointer]);
                firstPointer++;
            }
            else
            {
                chars.Add(s[secondPointer]);
                maxLength = Math.Max(maxLength, secondPointer - firstPointer + 1);
                secondPointer += 1;
            }
        }

        return maxLength;
    }
}