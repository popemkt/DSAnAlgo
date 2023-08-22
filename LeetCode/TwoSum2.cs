// URL: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
namespace LeetCode;

public class TwoSum2
{
    [Fact]
    public void Test()
    {
        var input = new[] { 2,3,4 };
        var input2 = 6;
        var expected = new[]{1,3};
        Assert.Equal(expected, TwoSumNo1(input, input2));
        Assert.Equal(expected, TwoSumNo2(input, input2));
    }

    public int[] TwoSumNo1(int[] numbers, int target)
    {
        //set 2 pointers
        var i1 = 0;
        var i2 = 1;
        while(numbers[i1] + numbers[i2] != target){
            if (numbers[i1] + numbers[i2] < target)//if sum is lower than target, move both
            {
                i1++;
                i2++;
                continue;
            }

            i1--;//if sum is greater, move the first back, so that it lessen
        }

        return new[] { i1 + 1, i2 + 1 };
    }
    
    
    public int[] TwoSumNo2(int[] numbers, int target)
    {
        //set 2 pointers, at first and last of array
        var i1 = 0;
        var i2 = numbers.Length - 1;
        while(i1 < i2)
        {
            var sum = numbers[i1] + numbers[i2];
            if (sum == target) break;
            if (sum < target)//if sum is lower than target, move first, as it INCREASES the sum
            {
                i1++;
                continue;
            }

            i2--;//if sum is lower than target, move first, as it DECREASES the sum
        }

        return new[] { i1 + 1, i2 + 1 };
    }
}