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
        Assert.Equal(expected, BinarySearchWithCoordinateTranslation(input, target));
        Assert.Equal(expected, DoubleBinarySearch(input, target));
    }
    public bool BinarySearchWithCoordinateTranslation(int[][] matrix, int target)
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

    public bool DoubleBinarySearch(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        // First binary search to find the potential row
        var top = 0;
        var bottom = rows - 1;
        
        while (top <= bottom)
        {
            var row = bottom + (top - bottom) / 2;
            
            if (target > matrix[row][cols - 1])
                top = row + 1;
            else if (target < matrix[row][0])
                bottom = row - 1;
            else
                // Found the row that might contain our target
                return BinarySearchRow(matrix[row], target);
        }
        
        return false;
    }
    
    private bool BinarySearchRow(int[] row, int target)
    {
        var left = 0;
        var right = row.Length - 1;
        
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            
            if (row[mid] == target)
                return true;
                
            if (target < row[mid])
                right = mid - 1;
            else
                left = mid + 1;
        }
        
        return false;
    }
}