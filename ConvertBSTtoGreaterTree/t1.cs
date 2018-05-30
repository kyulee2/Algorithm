/*
Given a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus sum of all keys greater than the original key in BST.
Example: 
Input: The root of a Binary Search Tree like this:
              5
            /   \
           2     13

Output: The root of a Greater Tree like this:
             18
            /   \
          20     13
*/
// Comment: Just start visit right and aggregate sum by returning it.

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
    int Rec(TreeNode r, int s)
    {
        int sum = s;
        if (r.right != null) {
            sum = Rec(r.right, s);
        }
        r.val += sum;
        if (r.left != null) {
            return Rec(r.left, r.val);
        }        
        return r.val;
    }
    
    public TreeNode ConvertBST(TreeNode root) {
        if (root==null) return null;
        Rec(root, 0);
        return root;
    }
}

