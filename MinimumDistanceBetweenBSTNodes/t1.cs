/*
Given a Binary Search Tree (BST) with the root node root, return the minimum difference between the values of any two different nodes in the tree.

Example :

Input: root = [4,2,6,1,3,null,null]
Output: 1
Explanation:
Note that root is a TreeNode object, not an array.

The given tree [4,2,6,1,3,null,null] is represented by the following diagram:

          4
        /   \
      2      6
     / \    
    1   3  

while the minimum difference in this tree is 1, it occurs between node 1 and node 2, also between node 3 and node 2.
Note:

The size of the BST will be between 2 and 100.
The BST is always valid, each node's value is an integer, and each node's value is different.
*/
// Comment: Basically find minium distance in a consecutive number in an sorted array.
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
    void Rec(TreeNode root)
    {
        if (root==null) return;
        Rec(root.left);
        int val = root.val;
        int d = val - prev;
        min = Math.Min(min, d);
        prev = val;
        Rec(root.right);
    }
    int min;
    int prev;
    public int MinDiffInBST(TreeNode root) {
        min = 100;
        prev = -100;
        Rec(root);
        return min;
    }
}

