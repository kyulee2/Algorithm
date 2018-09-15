/*
Given a binary tree, count the number of uni-value subtrees.
A Uni-value subtree means all nodes of the subtree have the same value.
Example :
Input:  root = [5,1,5,5,5,null,5]

              5
             / \
            1   5
           / \   \
          5   5   5

Output: 4
*/
// Comment: Bottom-up. O(n)
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
    public int CountUnivalSubtrees(TreeNode root) {
        int cnt = 0;
        bool Rec(TreeNode n)
        {
            if (n==null)
                return true;
            bool l = Rec(n.left);
            bool r = Rec(n.right);
            if (!l || !r)
                return false;
            if (n.left==null && n.right==null) {
                cnt++;
                return true;
            }
            
            if (n.left==null && n.right != null) {
                if (n.val == n.right.val) {
                    cnt++;
                    return true;
                }
                return false;
            }
            if (n.left!=null && n.right== null) {
                if (n.val == n.left.val) {
                    cnt++;
                    return true;
                }
                return false;
            }       
            if (n.val == n.left.val && n.val == n.right.val) {
                cnt++;
                return true;
            }
            return false;
        }
        Rec(root);
        return cnt;
    }
}