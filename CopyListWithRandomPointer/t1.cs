/*
A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.

Return a deep copy of the list.
*/
// Comment: The first one is O(n) time with O(n) space using map.
// The second one is O(n) time with O(1) space
/**
 * Definition for singly-linked list with a random pointer.
 * public class RandomListNode {
 *     public int label;
 *     public RandomListNode next, random;
 *     public RandomListNode(int x) { this.label = x; }
 * };
 */
public class Solution {
    public RandomListNode CopyRandomList(RandomListNode head) {
        var map = new Dictionary<RandomListNode, RandomListNode>();
        var q = new Queue<RandomListNode>();
        if (head==null) return null;
        q.Enqueue(head);        
        while(q.Count != 0) {
            var old = q.Dequeue();
            if (map.ContainsKey(old))
                continue;
            map[old] = new RandomListNode(old.label);
            
            if (old.next != null)
                q.Enqueue(old.next); 
            if (old.random != null)
                q.Enqueue(old.random); 
        }
        
        foreach(var n in map.Keys) {
            if (n.next != null)
                map[n].next = map[n.next];
            if (n.random != null)
                map[n].random = map[n.random];            
        }
        
        return map[head];
    }
}
// O(1) space. Retain map between old to new by simply concatenating.
// Spoiler about handling null cases
/**
 * Definition for singly-linked list with a random pointer.
 * public class RandomListNode {
 *     public int label;
 *     public RandomListNode next, random;
 *     public RandomListNode(int x) { this.label = x; }
 * };
 */
public class Solution {
    public RandomListNode CopyRandomList(RandomListNode head) {
        if (head==null) return null; // spoiler
        
        // back-to-back copy
        var o = head;
        while(o!= null) {
            var n = new RandomListNode(o.label);
            var next = o.next;
            o.next = n;
            n.next = next;
            o = next;
        }
        
        // Update random from o
        o = head;
        while(o!=null) {
            var n = o.next;
            n.random = o.random == null ? null : o.random.next;
            o = n.next;
        }
        
        // Split
        o = head;
        var ans = o.next;        
        while(o!=null) {
            var n = o.next;
            o.next = n.next;
            n.next = o.next == null ? null : o.next.next;
            o = o.next;
        }
        
        return ans;
    }
}
