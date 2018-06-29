/*
You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Follow up:
What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

Example:

Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 8 -> 0 -> 7
*/
// Comment: Straightforward. Just many computations.
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
        ListNode reverse(ListNode n) {
            ListNode prev = null;
            while(n != null) {
                ListNode next = n.next;
                n.next = prev;
                prev = n;
                n = next;
            }
            return prev;
        }
        // reverse l1, l2
        l1 = reverse(l1);
        l2 = reverse(l2);
        
        // add
        ListNode dummy = new ListNode(0);
        ListNode p = dummy;
        int c = 0;
        while(l1!= null || l2!= null) {
            int l = 0, r = 0;
            if (l1!=null) {
                l = l1.val;
                l1 = l1.next;
            }
            if (l2!=null) {
                r= l2.val;
                l2 = l2.next;
            }
            int s = l+ r + c;
            ListNode node = new ListNode(s%10);
            c = s / 10;
            p.next = node;
            p = node;
        }
        if (c!=0) {
            p.next = new ListNode(c);
            p = p.next;
        }
        
        // reverse output
        return reverse(dummy.next);
    }
}

