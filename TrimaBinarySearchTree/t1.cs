/*
Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.

Example 1:
Input: 
    1
   / \
  0   2

  L = 1
  R = 2

Output: 
    1
      \
       2
Example 2:
Input: 
    3
   / \
  0   4
   \
    2
   /
  1

  L = 1
  R = 3

Output: 
      3
     / 
   2   
  /
 1
*/
// Comment: Straightfoward. But need do think about how to simplify recursion.
// The key idea is when edge to child node is updated after it is visited.
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public TreeNode TrimBST(TreeNode root, int L, int R)
    {
        if (root == null)
            return null;
        int rootval = root.val;
        if (rootval < L && rootval < R)
            return TrimBST(root.right, L, R);
        if (rootval > L && rootval > R)
            return TrimBST(root.left, L, R);
        if (rootval == R)
        {
            root.right = null;
            var left = TrimBST(root.left, L, R);
            root.left = left;
        }
        else if (rootval == L)
        {
            root.left = null;
            var right = TrimBST(root.right, L, R);
            root.right = right;
        } else {
            var left = TrimBST(root.left, L, R);
            root.left = left;
            var right = TrimBST(root.right, L, R);
            root.right = right;
        }
        return root;
    }
}
