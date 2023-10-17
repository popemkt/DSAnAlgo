// URL: https://leetcode.com/problems/binary-search/description/ 

using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace LeetCode;

public class BinarySearchLC
{
    [Fact]
    public void Test()
    {
        var input = new[] { -1, 0, 3, 5, 9, 12 };
        var target = 9;
        var expected = 4;
        Assert.Equal(expected, BinarySearchTree(input, target));
        Assert.Equal(expected, BinarySearch(input, target));
    }

    //Naive approach of building binary tree??
    public int BinarySearchTree(int[] nums, int target)
    {
        var tree = BinTree.FromArray(nums);
        return tree.Search(target);
    }

    //Real binary search by partitioning
    public int BinarySearch(int[] nums, int target)
    {
        var (left, right) = (0, nums.Length - 1);
        int mid = (right - left) / 2;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target) return i;
            if (i < nums[mid])
            {
                right = mid;
            }
            else
            {
                left = mid;
            }

            mid = (right - left) / 2;
        }

        return -1;
    }

    class BinTree
    {
        public Node? Root { get; set; }

        public static BinTree FromArray(int[] array)
        {
            BinTree result = new BinTree();
            result.Root = new Node()
            {
                Index = 0,
                Val = array[0],
            };
            for (int i = 1; i < array.Length; i++)
            {
                Node curent = result.Root;

                while (true)
                {
                    if (array[i] < curent.Val)
                    {
                        if (curent.Left is not null)
                            curent = curent.Left;
                        else
                        {
                            curent.Left = new Node()
                            {
                                Index = i,
                                Val = array[i]
                            };
                            break;
                        }
                    }
                    else
                    {
                        if (curent.Right is not null)
                        {
                            curent = curent.Right;
                        }
                        else
                        {
                            curent.Right = new Node()
                            {
                                Index = i,
                                Val = array[i]
                            };
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public int Search(int val)
        {
            Node current = Root;
            while (current is not null)
            {
                if (val == current.Val) return current.Index;
                if (val < current.Val)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return -1;
        }
    }

    class Node
    {
        public int Val { get; set; }
        public int Index { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }
}