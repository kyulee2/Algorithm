/*
Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Example:
Given a binary tree 
          1
         / \
        2   3
       / \     
      4   5    
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

Note: The length of path between two nodes is represented by the number of edges between them.
*/
// Comment: Easy. Careful when returning the final result. Not Rec(int) but max.

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
    int Rec(TreeNode n)
    {
        if (n==null) return 0;
        
        int l = 0, r = 0;
        if (n.left != null)
            l = Rec(n.left) + 1;
        if (n.right != null)
            r = Rec(n.right) +1;
        
        if (l+r >max) max = l + r; 
        return Math.Max(l, r);
    }
        
    public int DiameterOfBinaryTree(TreeNode root) {
        max = 0;
        Rec(root);
        return max;
    }
}


