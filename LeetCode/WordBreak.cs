// URL: https://leetcode.com/problems/word-break/description/

namespace LeetCode;

public class WordBreakLC
{
    [Fact]
    public void Test()
    {
        var input = "leetcode";
        var wordDict = new List<string>() { "leet", "code" };
        var expected = true;
        Assert.Equal(expected, WordBreak(input, wordDict));
        Assert.Equal(expected, WordBreak2(input, wordDict));
    }

    private bool WordBreak2(string s, IList<string> wordDict)
    {
        //1. We'll have a dp for caching the results of a previous position where the word is successfully separated breakable
        //2. We then backtrack maxLen(times) number of characters from current i
        //3. While backtracking with index j, if dp[j] is true (means we checked that it's breakable), then we check if from j to i, if the subtring is in dict
        //4. If in, we mark dp[i] as True(breakable/saved)
        //5. Finally, if the end(dp[end]) is marked as True, the whole string is breakable
        int maxLen = wordDict.Max(x => x.Length);
        HashSet<string> dict = new HashSet<string>(wordDict);
        bool[] dp = new bool[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i - 1; j >= Math.Max(-1, i - maxLen); j--)
            {
                if ((j < 0 || dp[j]) && dict.Contains(s.Substring(j + 1, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length - 1];
    }

    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> dict = new HashSet<string>(wordDict);
        int[] breakable = new int[20];
        Array.Fill(breakable, -21);
        breakable[0] = -1;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                int len = i - (breakable[j] + 1) + 1;
                if (len > 20) continue;
                string word = s.Substring(breakable[j] + 1, len);
                if (dict.Contains(word))
                {
                    breakable[(i + 1) % 20] = i;
                    break;
                }
            }
        }

        return breakable[s.Length % 20] == s.Length - 1;
    }
}