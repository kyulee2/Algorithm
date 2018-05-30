/*
Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. 
You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of new tree. 
Example 1:
Input: 
	Tree 1                     Tree 2                  
          1                         2                             
         / \                       / \                            
        3   2                     1   3                        
       /                           \   \                      
      5                             4   7                  
Output: 
Merged tree:
	     3
	    / \
	   4   5
	  / \   \ 
	 5   4   7

Note: The merging process must start from the root nodes of both trees. 
*/

// Comment: The below does not clone it when one of part of tree is null, instead just use such point.
// This might be clarified. 
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
    void Rec(TreeNode n, TreeNode t1, TreeNode t2)
    {
        n.val = t1.val + t2.val;
        // Check left
        TreeNode t1l = t1.left;
        TreeNode t2l = t2.left;
        if (t1l != null && t2l == null)
            n.left = t1l; // Instead, we could clone it
        else if (t1l == null && t2l != null)
            n.left = t2l; // Instead, we could clone it
        else if (t1l != null && t2l != null) {
            n.left = new TreeNode(0);
            Rec(n.left, t1l, t2l);
        }
        
        // Check right
        TreeNode t1r = t1.right;
        TreeNode t2r = t2.right;
        if (t1r != null && t2r == null)
            n.right = t1r; // Instead, we could clone it
        else if (t1r == null && t2r != null)
            n.right = t2r; // Instead, we could clone it
        else if (t1r != null && t2r != null) {
            n.right = new TreeNode(0);
            Rec(n.right, t1r, t2r);
        }                    
    }
    
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2) {
        if (t1==null && t2==null) return null;
        if (t1!=null && t2==null) return t1;
        if (t1==null && t2!=null) return t2;
        TreeNode root = new TreeNode(0);
        Rec(root, t1, t2);
        
        return root;
    }
}

