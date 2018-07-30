/*
Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.
Example 1:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 9

Output: True

Example 2:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 28

Output: False
*/
// Comment: Use a set. O(n) for both space and speed.
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
    public bool FindTarget(TreeNode root, int k) {
        var set = new HashSet<int>();
        bool Rec(TreeNode n)
        {
            if (n==null) return false;
            if (Rec(n.left)) return true;
            if (set.Contains(k-n.val)) return true;
            set.Add(n.val);
            return Rec(n.right);
        }
        return Rec(root);
    }
}
