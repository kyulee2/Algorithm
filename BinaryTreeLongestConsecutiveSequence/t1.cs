/*
Given a binary tree, find the length of the longest consecutive sequence path.
The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The longest consecutive path need to be from parent to child (cannot be the reverse).
Example 1:
Input:

   1
    \
     3
    / \
   2   4
        \
         5

Output: 3

Explanation: Longest consecutive sequence path is 3-4-5, so return 3.
Example 2:
Input:

   2
    \
     3
    / 
   2    
  / 
 1

Output: 2 

Explanation: Longest consecutive sequence path is 2-3, not 3-2-1, so return 2.
*/

// Comment: Trivial

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
    
    int Rec(TreeNode n) {
        TreeNode l = n.left;
        TreeNode r = n.right;
        int la =0, ra = 0;
        if (l!= null) {
            la = Rec(l);
            if (n.val != l.val-1) la = 0;
        }
        if (r!=null) {
            ra = Rec(r);
            if (n.val != r.val-1) ra = 0;
        }
        int curr = Math.Max(la, ra) + 1;
        if (curr > max) max = curr;
        return curr;
    }
    public int LongestConsecutive(TreeNode root) {
        max = 0;
        if (root==null) return max;
        Rec(root);
        return max;
    }
}

