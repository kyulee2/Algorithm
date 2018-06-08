/*
Given a non-negative integer represented as non-empty a singly linked list of digits, plus one to the integer.

You may assume the integer do not contain any leading zero, except the number 0 itself.

The digits are stored such that the most significant digit is at the head of the list.

Example:
Input:
1->2->3

Output:
1->2->4
*/
// Comment: Reverse head and tail respectively
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    ListNode reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        while(curr != null) {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }
    public ListNode PlusOne(ListNode head) {
        ListNode tail = reverse(head);
        int c = 1;
        ListNode prev = null;
        ListNode curr = tail;
        while(c!= 0 && curr != null) {
            int val = curr.val + c;
            curr.val = val % 10;
            c = val / 10;
            prev = curr;
            curr = curr.next;
        }
        if (c!=0 && prev != null) {
            prev.next = new ListNode(c);
        }
        return reverse(tail);
    }
}

