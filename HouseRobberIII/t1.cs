/*
The thief has found himself a new place for his thievery again. There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that "all houses in this place forms a binary tree". It will automatically contact the police if two directly-linked houses were broken into on the same night.

Determine the maximum amount of money the thief can rob tonight without alerting the police.

Example 1:
     3
    / \
   2   3
    \   \ 
     3   1
Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
Example 2:
     3
    / \
   4   5
  / \   \ 
 1   3   1
Maximum amount of money the thief can rob = 4 + 5 = 9.
*/
// Comment: Initially thought about queue to traverse level sum, or passing list to get sum of each level, and do HouseRobber alogrithm on it. But that is not correct.
// The key point is to pass up from child and grand child node summary.
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
    public int Rob(TreeNode root) {
        int[] Rec(TreeNode n)
        {
            if (n==null)
                return new int[]{0,0};
            var l = Rec(n.left);
            var r = Rec(n.right);
            var ans = new int[2];
            ans[0] = Math.Max(l[0]+r[0], n.val + l[1] + r[1]);
            ans[1] = l[0] + r[0];
            return ans;
        }
        var t = Rec(root);
        return t[0];
    }
}

