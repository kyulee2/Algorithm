/*
Find the sum of all left leaves in a given binary tree.
Example: 
    3
   / \
  9  20
    /  \
   15   7

There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.
*/
// Comment: Easy
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
    public int SumOfLeftLeaves(TreeNode root) {
        if (root==null) return 0;
        int sum = 0;
        void Rec(TreeNode n, bool isLeft) {
            if (n.left == null && n.right==null) {
                if (isLeft)
                    sum += n.val;
                return;
            }
            if (n.left != null)
                Rec(n.left, true);
            if (n.right != null)
                Rec(n.right, false);
        }
        Rec(root, false);
        return sum;
    }
}