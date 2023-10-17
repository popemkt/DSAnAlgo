// See https://aka.ms/new-console-template for more information

Console.WriteLine(MinBulbsNeededToLightStreet(new int[]{-1, 2, 2, -1, 0, 0})); // Output: 2
Console.WriteLine(MinBulbsNeededToLightStreet(new int[]{2, 3, 4, -1, 2, 0, 0, -1, 0})); // Output: -1

static int MinBulbsNeededToLightStreet(int[] bulbs)
{
    int n = bulbs.Length;
    int[] dp = new int[n+1];
    dp[n] = 0;
    int rightLightCorner = n;
    SortedSet<int[]> availableBulbs = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : b[0] - a[0]));

    for (int i = n - 1; i >= 0; i--)
    {
        while (availableBulbs.Count > 0 && availableBulbs.Min[0] < i)
            availableBulbs.Remove(availableBulbs.Min);

        if (bulbs[i] >= 0)
        {
            dp[i] = 1 + (availableBulbs.Count > 0 ? dp[availableBulbs.Min[1] + 1] : 0);
            while (i + bulbs[i] + 1 > rightLightCorner)
            {
                rightLightCorner--;
                dp[i] = Math.Min(dp[i], 1 + dp[rightLightCorner + 1]);
            }
        }
        else if (availableBulbs.Count > 0)
        {
            dp[i] = dp[availableBulbs.Min[1] + 1];
        }
        else
        {
            return -1;
        }

        if (bulbs[i] >= 0)
            availableBulbs.Add(new int[] { i + bulbs[i], i });
    }

    return dp[0];
}