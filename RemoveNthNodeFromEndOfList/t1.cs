/*
Given a linked list, remove the n-th node from the end of list and return its head.

Example:

Given linked list: 1->2->3->4->5, and n = 2.

After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:

Given n will always be valid.

Follow up:

Could you do this in one pass?
*/
// Comment: Use dummy and pre-move with delta.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if (n==0)
            return head;
        var dummy = new ListNode(0);
        dummy.next = head;
        var prev = dummy;
        var curr = head;
        while(curr!=null && n>0) {
            curr = curr.next;
            n--;
        }
        
        while(curr!=null) {
            curr = curr.next;
            prev = prev.next;
        }
        
        prev.next = prev.next.next;
        
        return dummy.next;
    }
}

