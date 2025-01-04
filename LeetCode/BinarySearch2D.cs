// URL: https://leetcode.com/problems/search-a-2d-matrix/

namespace LeetCode;

public class BinarySearch2D
{
    [Fact]
    public void Test()
    {
        int[][] input =
        {
            new int[] { 1, 3, 5, 7 },
            new int[] { 10, 11, 16, 20 },
            new int[] { 23, 30, 34, 60 }
        };
        var target = 23;
        var expected = true;
        Assert.Equal(expected, BinarySearch(input, target));
    }

    public bool BinarySearch(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        int ToFlat(int row, int col)
        {
            return col * (row - 1) + col;
        }

        (int Row, int Col) ToMat(int flat)
        {
            return (flat / cols, flat % cols);
        }

        var (left, right) = (0, ToFlat(rows, cols) - 1);

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var midMat = ToMat(mid);

            if (matrix[midMat.Row][midMat.Col] == target)
                return true;

            if (target < matrix[midMat.Row][midMat.Col])
                right = mid - 1;
            else
                left = mid + 1;
        }

        return false;
    }
}