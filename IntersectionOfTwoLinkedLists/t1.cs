/*
Write a program to find the node at which the intersection of two singly linked lists begins.


For example, the following two linked lists:

A:          a1 ? a2
                   ?
                     c1 ? c2 ? c3
                   ?            
B:     b1 ? b2 ? b3
begin to intersect at node c1.


Notes:

If the two linked lists have no intersection at all, return null.
The linked lists must retain their original structure after the function returns.
You may assume there are no cycles anywhere in the entire linked structure.
Your code should preferably run in O(n) time and use only O(1) memory.
*/
// Comment: Use length to align starting position.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        int getLen(ListNode n)
        {
            int h = 0;
            while(n != null) {
                h++;
                n = n.next;
            }
            return h;
        }
        ListNode move(ListNode n, int h)
        {
            while(h>0) {
                n = n.next;
                h--;
            }
            return n;
        }
        
        int len1 = getLen(headA);
        int len2 = getLen(headB);
        if (len1>len2)
            headA = move(headA, len1-len2);
        else if (len1<len2)
            headB = move(headB, len2-len1);
        
        // Main detection
        while(headA != null) {
            if (headA == headB)
                return headA;
            headA = headA.next;
            headB = headB.next;
        }
        
        return null;
    }
}
