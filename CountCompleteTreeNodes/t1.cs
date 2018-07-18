/*
Given a complete binary tree, count the number of nodes.

Note:

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

Example:

Input: 
    1
   / \
  2   3
 / \  /
4  5 6

Output: 6
*/
// Comment: This is O((logN)^2)
// Check the height of left against the height of right child.
// If they are identical, the last row ends at the right child. Add count 1 (curr) + (1<<(left) - 1)
// recursion on the right child.
// Otherwise, flip the operation above
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
    int getHeight(TreeNode n)
    {
        int cnt = 0;
        while(n != null) {
            n = n.left;
            cnt++;
        }
        return cnt;
    }
    public int CountNodes(TreeNode root) {
        if(root==null) return 0;
        int left = getHeight(root.left);
        int right = getHeight(root.right);
        if (left == right)
            return (1<<left) + CountNodes(root.right);
        else
            return (1<<right) + CountNodes(root.left);
    }
}
