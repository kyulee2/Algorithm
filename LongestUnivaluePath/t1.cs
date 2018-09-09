/*
Given a binary tree, find the length of the longest path where each node in the path has the same value. This path may or may not pass through the root.
Note: The length of path between two nodes is represented by the number of edges between them.
Example 1: 
Input: 
              5
             / \
            4   5
           / \   \
          1   1   5

Output: 
2

Example 2: 
Input: 
              1
             / \
            4   5
           / \   \
          4   4   5

Output: 
2

Note: The given binary tree has not more than 10000 nodes. The height of the tree is not more than 1000. 
*/

// Comment: Initialize local regardless of conditions otherwise warning/errors
// Rec() returns the longest path (either from left or right child). Tha max path should be updated in separate to combine both childrens. So do not directly return Rec() to the answer.

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
    void updateMax(int c)
    {
        if (c>max) max = c;
    }
    int Rec(TreeNode n) {
        TreeNode l = n.left;
        TreeNode r = n.right;
        int la = 0, ra = 0;
        int ans = 0;
        
        if (l!= null) {
            la = Rec(l);
            if (l.val == n.val)
                ans = la + 1;
        }
        if (r!= null) {
            ra = Rec(r);
            if (r.val == n.val)
                ans = ra + 1;
        }
        if (l!= null && r != null) {            
            if (l.val == n.val && r.val == n.val) {
                ans = Math.Max(la, ra) + 1;
                updateMax(la + ra + 2);
                return ans;
            }
        }
        
        updateMax(ans);
        return ans;
        
    }
    public int LongestUnivaluePath(TreeNode root) {
        if (root==null) return 0;
        max = 0;
        Rec(root);
        return max;
    }
}
// Comment: Similar one
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
    public int LongestUnivaluePath(TreeNode root) {
        int ans = 0;
        
        int Rec(TreeNode n) {
            if (n==null) return 0;
            int left = Rec(n.left);
            int right = Rec(n.right);
            bool sameLeft = false, sameRight = false;
            if (n.left != null && n.left.val == n.val) {
                left++;
                sameLeft = true;
            }
            if (n.right != null && n.right.val == n.val) {
                right++;
                sameRight = true;
            }
            
            if (sameLeft && sameRight) {
                int curr = left + right;
                ans = Math.Max(ans, curr);
                return Math.Max(left, right);
            }
            else if (sameLeft && !sameRight) {
                ans = Math.Max(ans, left);
                return left;
            }
            else if (!sameLeft && sameRight) {
                ans = Math.Max(ans, right);
                return right;
            }
            return 0;
        }
        Rec(root);
        return ans;
    }
}
