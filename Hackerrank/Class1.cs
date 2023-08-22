namespace Hackerrank;

Console.Write



static int MinBulbsNeededToLightStreet(int[] arr)
{
    int n = arr.Length;
    var dp = new int[n];
    for (int i = 0; i < n; ++i)
    {
        dp[i] = int.MaxValue;
        if (arr[i] < 0) continue;
        int left = i - arr[i] > 0 ? i - arr[i] : 0;
        int right = i;

        if (left == 0) dp[right] = 1;
        else
        {
            for (int j = left; j < right; ++j)
            {
                if (dp[j] < int.MaxValue)
                    dp[right] = Math.Min(dp[right], dp[j] + 1);
            }
        }
    }

    return dp[n - 1] == int.MaxValue ? -1 : dp[n - 1];
}