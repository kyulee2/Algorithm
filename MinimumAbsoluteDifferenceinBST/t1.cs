/*
Pick One

Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.
Example: 
Input:

   1
    \
     3
    /
   2

Output:
1

Explanation:
The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).

Note: There are at least two nodes in this BST. 
*/
// Comment: Easy. Just find minimum distance of consecutive two node in order
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
    int min;
    TreeNode prev;
    void Rec(TreeNode n)
    {
        if (n==null) return;
        Rec(n.left);
        if (prev != null) {
            int d = n.val - prev.val;
            min = Math.Min(min, d);
        }
        prev = n;
        Rec(n.right);
    }
    public int GetMinimumDifference(TreeNode root) {
        prev = null;
        min = Int32.MaxValue;
        Rec(root);
        return min;
    }
}
