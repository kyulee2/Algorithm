/*
Input: 1->2
Output: false
Example 2:
Input: 1->2->2->1
Output: true
Follow up:
Could you do it in O(n) time and O(1) space?
*/

// Comment: Just be careful syntax. The below is O(n) time and O(1) space, with modification in place.
// If the input shoud be in-tact, additional reverse/splice operations are needed -- no change in complexity
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    int getLen(ListNode head) {
        int n = 0;
        while(head != null) {
            n++;
            head= head.next;
        }
        return n;
    }
    ListNode reverse(ListNode head) {
        if (head == null) return head;
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
    bool isMatch(ListNode left, ListNode right)
    {        
        while(left != null && right != null)
        {
            if (left.val != right.val) return false;
            left = left.next;
            right = right.next;
        }
        return true;
    }
    public bool IsPalindrome(ListNode head) {
        // Get len
        int len = getLen(head);
        if (len <= 1) return true;
        
        // Split it in half -- left, right
        ListNode prev = null;
        ListNode curr = head;
        for(int i=0; i< len/2; i++) {
            ListNode next = curr.next;
            prev = curr;
            curr = next;
        }        
        prev.next = null;
        
        // Reverse right
        ListNode r = reverse(curr);
        
        // Check left and right match
        bool ans = isMatch(head, r);
        
        // Reverse right (optional)
        // Splice left right back (optional)
        return ans;
    }
}