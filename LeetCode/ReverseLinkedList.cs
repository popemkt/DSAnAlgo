// URL: https://leetcode.com/problems/reverse-linked-list/ 

namespace LeetCode;

public class ReversedLinkedList
{
    public class ListNode
    {
        public int Val;
        public ListNode? Next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.Val = val;
            this.Next = next;
        }
    }

    [Fact]
    public void Test()
    {
        var result = Algo(NewInput());
        var result2 = ReverseList(NewInput());
        var result3 = ReverseListRecursive(NewInput());
    }

    private ListNode NewInput() =>
        new(
            1,
            new ListNode(
                2,
                new ListNode(
                    3,
                    new ListNode(
                        4,
                        new ListNode(
                            5
                        )
                    )
                )
            ));

    public ListNode? Algo(ListNode s)
    {
        ListNode prev = null;
        while (s is not null)
        {
            if (prev is null)
            {
                prev = new ListNode(s.Val);
                continue;
            }

            prev = new ListNode(s.Val, prev);
            s = s.Next;
        }

        return prev;
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

// The rationale behind the recursive approach to reversing a linked list is based on the idea of breaking down the problem into smaller subproblems and solving them recursively. Let's break down the thought process:
//
// 1. Base case: 
//    - We first consider the base case, which is the simplest scenario where the recursion should stop. 
//    - In the case of reversing a linked list, the base case is when the list is empty (`head == null`) or contains only one node (`head.Next == null`). 
//    - In these cases, the list is already reversed, so we simply return the `head`.
//
// 2. Recursive case:
//    - For the recursive case, we assume that the recursive function will reverse the sublist starting from `head.Next` and return the new head of the reversed sublist.
//    - We make a recursive call `ReverseList(head.Next)` to reverse the sublist and store the returned new head in `newHead`.
//    - After the recursive call, `head.Next` points to the last node of the reversed sublist.
//
// 3. Reversing the link:
//    - Now, we need to reverse the link between the current node (`head`) and the reversed sublist.
//    - We set `head.Next.Next` to `head`, effectively reversing the link.
//    - We set `head.Next` to `null` to break the original link and avoid creating a cycle.
//
// 4. Returning the new head:
//    - Finally, we return `newHead`, which is the new head of the reversed list.
//    - The recursive calls will backtrack, and each call will reverse the link between the current node and the reversed sublist.
//
// The key idea is that we trust the recursive function to reverse the sublist starting from `head.Next`, and we only focus on reversing the link between the current node and the reversed sublist. By recursively applying this process, we eventually reverse the entire linked list.
//
// Here's a step-by-step visualization of the recursion:
// ```
// Original list: 1 -> 2 -> 3 -> 4 -> 5 -> null
//
// Recursive calls:
// ReverseList(1)
//    |-- ReverseList(2)
//          |-- ReverseList(3)
//                |-- ReverseList(4)
//                      |-- ReverseList(5)
//                            |-- Base case: return 5
//                      |-- Set 5.Next = 4, 4.Next = null, return 5
//                |-- Set 4.Next = 3, 3.Next = null, return 5
//          |-- Set 3.Next = 2, 2.Next = null, return 5
//    |-- Set 2.Next = 1, 1.Next = null, return 5
//
// Final reversed list: 5 -> 4 -> 3 -> 2 -> 1 -> null
// ```
//
// The recursion starts from the head of the list and goes deeper until it reaches the base case. Then, it backtracks and reverses the links along the way, ultimately reversing the entire list.
//
// The recursive approach provides a concise and elegant solution to the problem, as it breaks down the reversal process into smaller subproblems and solves them recursively. However, it's important to consider the space complexity of the recursive approach, as it uses the call stack and may not be suitable for very large lists.
    public ListNode ReverseListRecursive(ListNode head)
    {
        if (head == null || head.Next == null)
            return head;

        ListNode newHead = ReverseListRecursive(head.Next);
        head.Next.Next = head;
        head.Next = null;

        return newHead;
    }
}