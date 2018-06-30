/*
Given a binary tree, flatten it to a linked list in-place.

For example, given the following tree:

    1
   / \
  2   5
 / \   \
3   4   6
The flattened tree should look like:

1
 \
  2
   \
    3
     \
      4
       \
        5
         \
          6
*/
// Comment: Straightforward. Don't forget clearing left node.
// Try to combine common code for left != null && right !=null
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
    TreeNode Rec(TreeNode n)
    {
        if(n==null) return null;
        var left = n.left;
        var right = n.right;
        
        if (left!=null) {
            n.left = null;
            n.right = left;
            left = Rec(left);
            left.right = right;
        }
        if (right!=null) {
            return Rec(right);
        }
        return left == null ? n : left;
    }
    public void Flatten(TreeNode root) {
        Rec(root);
    }
}
