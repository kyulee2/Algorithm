/*
Reverse a singly linked list.
Example:
Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL
Follow up:
A linked list can be reversed either iteratively or recursively. Could you implement both?
*/
// Comment: Recursion form of reverse linked list. 
// See t1.cs for iterative one.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    ListNode Rec(ListNode prev, ListNode curr)
    {
        if (curr == null)
            return prev;
        ListNode next = curr.next;
        curr.next = prev;
        return Rec(curr, next);
    }
    public ListNode ReverseList(ListNode head) {
        if (head == null) return null;
        ListNode prev = null;
        ListNode curr = head;
        return Rec(prev, curr);
    }
}