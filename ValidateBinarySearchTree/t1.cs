/*
Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
Example 1:

Input:
    2
   / \
  1   3
Output: true
Example 2:

    5
   / \
  1   4
     / \
    3   6
Output: false
Explanation: The input is: [5,1,4,null,null,3,6]. The root node's value
             is 5 but its right child's value is 4.
*/
// Comment: Walk in BST to see if it's in order.
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
    public bool IsValidBST(TreeNode root) {
        bool hasPrev = false;
        int prev = 0;
        bool Rec(TreeNode n) {
            if (n==null) return true;
            var l = Rec(n.left);
            if (!l) return false;
            int val = n.val;
            if (!hasPrev) {
                hasPrev = true;
            } else {
                if (prev >= val)
                    return false;
            }
            // upate prev
            prev = val;
            return Rec(n.right);
        }
        
        return Rec(root);
    }
}

