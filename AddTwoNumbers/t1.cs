/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
*/
// Comment: Straightforward
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
   
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var dummy = new ListNode(0);
        var prev = dummy;
        int c = 0;
        while(l1!=null || l2!=null) {
            int l=0, r=0;
            if (l1!=null) {
                l = l1.val;
                l1 = l1.next;
            }
            if (l2!=null) {
                r = l2.val;
                l2 = l2.next;
            }
            int s = l+r+c;
            c = s / 10;
            prev.next = new ListNode(s%10);
            prev = prev.next;
        }
        if (c>0) {
            prev.next = new ListNode(c);
        }
        return dummy.next;
    }
}
