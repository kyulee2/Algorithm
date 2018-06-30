/*
Given a linked list, determine if it has a cycle in it.

Follow up:
Can you solve it without using extra space?
*/
// Comment: Straightforward
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        var curr = head;
        if (curr ==null) return false;
        var next = curr.next;
        if (next==null) return false;
        var fast = next.next;;
        while(curr != null && fast !=null) {
            if (curr == fast)
                return true;
            curr = curr.next;
            fast = fast.next;
            if (fast != null)
                fast = fast.next;
        }
        return false;
    }
}

