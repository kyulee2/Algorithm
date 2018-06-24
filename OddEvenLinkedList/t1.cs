/*
Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

Example 1:

Input: 1->2->3->4->5->NULL
Output: 1->3->5->2->4->NULL
Example 2:

Input: 2->1->3->5->6->4->7->NULL
Output: 2->3->6->7->1->5->4->NULL
Note:

The relative order inside both the even and odd groups should remain as it was in the input.
The first node is considered odd, the second node even and so on ...
*/
// Comment: Easy. Use empty header. Don't need prev since we always remove it from the header.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode OddEvenList(ListNode head) {
        var odd = new ListNode(0);
        var even = new ListNode(0);
        var ansprev = odd;
        var evenprev = even;
        var curr = head;
        
        // Insert odd/even to each list
        bool IsOdd = true;
        while(curr != null) {
            var next = curr.next;
            if (IsOdd) {
                odd.next = curr;
                odd = curr;
            } else {
                even.next = curr;
                even = curr;
            }
            curr.next = null;
            IsOdd = !IsOdd;
            curr = next;
        }
        
        // Splice odd to even
        odd.next = evenprev.next;
        
        return ansprev.next;
    }
}

