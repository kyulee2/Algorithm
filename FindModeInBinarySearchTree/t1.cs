/*
Given a binary search tree (BST) with duplicates, find all the mode(s) (the most frequently occurred element) in the given BST.

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than or equal to the node's key.
The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
Both the left and right subtrees must also be binary search trees.
For example:
Given BST [1,null,2,2],
   1
    \
     2
    /
   2
return [2].

Note: If a tree has more than one mode, you can return them in any order.

Follow up: Could you do that without using any extra space? (Assume that the implicit stack space incurred due to recursion does not count).
*/
// Comment: Didn't use exta space like map, but run twice -- first to get max count and second to publish nodes with max count.
// Didn't investigate one pass logic or others yet.
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    int max;
    TreeNode prev;
    int prevCnt;
    void Rec(TreeNode n)
    {
        if (n==null) return;
        Rec(n.left);
        if (prev==null || prev.val != n.val)
            prevCnt = 1;
        else
            prevCnt++;
        max = Math.Max(max, prevCnt);
        prev = n;
        Rec(n.right);
    }
    void Rec2(TreeNode n)
    {
        if (n==null) return;
        Rec2(n.left);
        if (prev==null || prev.val != n.val)
            prevCnt = 1;
        else
            prevCnt++;
        if (prevCnt == max)
            ans.Add(n.val);
        prev = n;
        Rec2(n.right);
    } 
    HashSet<int> ans;
    public int[] FindMode(TreeNode root) {
        prev = null;
        ans = new HashSet<int>();
        Rec(root);
        
        prev = null;
        Rec2(root);
        return ans.ToList().ToArray();
    }
}
