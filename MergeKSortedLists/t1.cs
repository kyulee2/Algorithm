/*
Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

Example:

Input:
[
  1->4->5,
  1->3->4,
  2->6
]
Output: 1->1->2->3->4->4->5->6
*/
// Comment: All about building heap. 
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    class Heap {
    public List<ListNode> l;
    public Heap() {
        l = new List<ListNode>();
        l.Add(new ListNode(0)); // dummy at 0 index
    }
    // # of elements in this heap and also the last index 
    // since we started from 1.
    public int Count {
        get {
            return l.Count - 1;
        }
    }

    public ListNode Top() {
        var ans = l[1];
        Swap(1, Count);
        l.RemoveAt(Count);
        Down(1);
        return ans;
    }        
    public void Add(ListNode n)
    {
        // Spoiler: Check null node
        if (n== null) return;
        l.Add(n);
        Up(Count);
    }
    void Up(int i)
    {
        while(i>1) {
            var p = l[i/2].val;
            if (p<=l[i].val)
                break;
            Swap(i/2, i);
            i /= 2;
        }
    }
    void Down(int i)
    {
        if (i>Count) return;
        var left = i*2 > Count ? Int32.MaxValue : l[i*2].val;
        var right = (i*2 +1) >Count ?Int32.MaxValue: l[i*2+1].val;
        if (left < right) {
            if (left < l[i].val) {
                Swap(i*2, i);
                Down(i*2);
            }
        } else {
            if (right < l[i].val) {
                Swap(i*2 +1, i);
                Down(i*2 + 1);
            }            
        }
    }
    void Swap(int i, int j) {
        var t = l[i];
        l[i] = l[j];
        l[j] = t;
    }
    }
    
    public ListNode MergeKLists(ListNode[] lists) {
        var h = new Heap();
        foreach(var n in lists)
            h.Add(n);
        
        var ansprev = new ListNode(0);
        ListNode prev = ansprev;
        while(h.Count != 0) {
            var n = h.Top();
            prev.next = n;
            var t = n.next;
            n.next = null;
            if (t != null)
                h.Add(t);
            prev = n;
        }
        
        return ansprev.next;
    }
}
