/*
Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

Note: If the given node has no in-order successor in the tree, return null.

Example 1:

Input: root = [2,1,3], p = 1

  2
 / \
1   3

Output: 2
Example 2:

Input: root = [5,3,6,2,4,null,null,1], p = 6

      5
     / \
    3   6
   / \
  2   4
 /   
1

Output: null
*/
// Comment: Should be easy. Be careful ending condition
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
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode prev = null;
        TreeNode Rec(TreeNode n, TreeNode target) {
            if (n==null)
                return null;
            var l = Rec(n.left, target);
            if (l!=null)
                return l;
            if (prev != null && prev.val == target.val)
                return n;
            prev = n;
            return Rec(n.right, target);
        }
        return Rec(root, p);
    }
}

