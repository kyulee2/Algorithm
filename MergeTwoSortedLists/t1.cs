/*
Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.

Example:

Input: 1->2->4, 1->3->4
Output: 1->1->2->3->4->4
*/
// Comment: Straighforward
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
// Comment: Use dummy header
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode prevans = new ListNode(0);
        var prev =prevans;
        while(l1!=null && l2!=null) {
            if (l1.val<l2.val) {
                prev.next = new ListNode(l1.val);
                l1 = l1.next;
            } else {
                prev.next = new ListNode(l2.val);
                l2 = l2.next;
            }
            prev = prev.next;
        }
        while(l1!=null) {
            prev.next = new ListNode(l1.val);
            l1 = l1.next;
            prev = prev.next;
        }
        while(l2!=null) {
            prev.next = new ListNode(l2.val);
            l2 = l2.next;
            prev = prev.next;
        }
        return prevans.next;
    }
}
