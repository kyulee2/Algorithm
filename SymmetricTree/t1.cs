/*
Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
For example, this binary tree [1,2,2,3,4,4,3] is symmetric: 
    1
   / \
  2   2
 / \ / \
3  4 4  3

But the following [1,2,2,null,3,null,3] is not:
    1
   / \
  2   2
   \   \
   3    3

Note:
Bonus points if you could solve it both recursively and iteratively. 
*/
// Comment: Recurse left and right pair
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
    public bool IsSymmetric(TreeNode root) {
        if (root==null) return true;
        bool Rec(TreeNode l, TreeNode r) {
            if (l==null && r==null) return true;
            if (l!=null && r==null) return false;
            if (l==null && r!=null) return false;
            if (l.val != r.val) return false;
            
            var left = Rec(l.left, r.right);
            var right = Rec(l.right, r.left);
            return left && right;
        }
        
        return Rec(root.left, root.right);
    }
}
