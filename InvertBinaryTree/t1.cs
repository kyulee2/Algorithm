/*
Invert a binary tree.

Example:

Input:

     4
   /   \
  2     7
 / \   / \
1   3 6   9
Output:

     4
   /   \
  7     2
 / \   / \
9   6 3   1
*/

// Comment: Spoiler: Don't attemp to update val in place
// Invert means structurally mirrored. [1, 2] --> [1, null, 2]
// The key point is to swap left/right child

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
    void Rec(TreeNode n)
    {
        if (n==null) return;
        TreeNode l = n.left;
        TreeNode r = n.right;
        n.right = l;
        n.left = r;
        Rec(l);
        Rec(r);
    }
    public TreeNode InvertTree(TreeNode root) {
        Rec(root);
        return root;
    }
}

