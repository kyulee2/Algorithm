/*
Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.
Note:
Given target value is a floating point.
You are guaranteed to have only one unique value in the BST that is closest to the target.
Example:
Input: root = [4,2,5,1,3], target = 3.714286

    4
   / \
  2   5
 / \
1   3

Output: 4
*/

// Comment: Should be easy, but tumbled since forgot using BST property.
// Initially, I thought getting minimal distance between childs and recursively visit toward them.
// As below, simply we get minimal distance by traversing BST.
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
    
    double minDist;
    int ans;
    void Rec(TreeNode root, double target)
    {
        if (root==null) return;
        double dist = Math.Abs(target-(double)root.val);
        if (dist < minDist) {
            minDist = dist;
            ans = root.val;
        }
        if (target < (double)root.val)
            Rec(root.left, target);
        else
            Rec(root.right, target);            
    }
    
    public int ClosestValue(TreeNode root, double target) {
        minDist = (double)Int64.MaxValue;
        Rec(root, target);
        return ans;
    }
}
