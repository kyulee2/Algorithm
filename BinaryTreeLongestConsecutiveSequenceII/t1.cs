/*
Given a binary tree, you need to find the length of Longest Consecutive Path in Binary Tree.

Especially, this path can be either increasing or decreasing. For example, [1,2,3,4] and [4,3,2,1] are both considered valid, but the path [1,2,4,3] is not valid. On the other hand, the path can be in the child-Parent-child order, where not necessarily be parent-child order.

Example 1:
Input:
        1
       / \
      2   3
Output: 2
Explanation: The longest consecutive path is [1, 2] or [2, 1].
Example 2:
Input:
        2
       / \
      1   3
Output: 3
Explanation: The longest consecutive path is [1, 2, 3] or [3, 2, 1].
Note: All the values of tree nodes are in the range of [-1e7, 1e7].
*/
// Comment: Initially, I thought passing direction along with maximum length from child to pass up.
// This actually doesn't work since even smaller child can end up with contributing maximum length.
// So, we should pass both either increase or decrease path length upward.
// Don't forget using "out" parameters. We might consider pass a struct that has a pair value.
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
    int id;
    void Rec(TreeNode n, out int ic, out int dc) // Output: increase length/decrease length
    {
        TreeNode l = n.left;
        TreeNode r = n.right;
        if (l==null && r==null) {
            ic = 0;
            dc = 0;
            return;
        }

        int lic = 0, ric = 0;
        int ldc = 0, rdc = 0;
        if (l!=null) {
            Rec(l, out lic, out ldc);
            if (l.val+1 == n.val) {
                ldc++;
                lic = 0;
            }  else if (l.val-1 == n.val) {
                lic++;
                ldc = 0;
            } else {
                ldc = 0;
                lic = 0;
            }
        }
        if (r!=null) {
            Rec(r, out ric, out rdc);
            if (r.val+1 == n.val) {
                rdc++;
                ric = 0;
            }  else if (r.val-1 == n.val) {
                ric++;
                rdc = 0;
            } else {
                rdc = 0;
                ric = 0;
            }
        }        

        if (((lic>0) && (rdc>0))) {
            int total = lic + rdc + 1;
            if (total>max) max = total;
        }
        if (((ldc>0) && (ric>0))) {
            int total = ric + ldc + 1;
            if (total>max) max = total;
        }
             
        // Output ic/dc with the max count either form left/right
        ic = lic > ric ? lic : ric;
        if (ic + 1 > max) max = ic + 1;
        dc = ldc > rdc ? ldc : rdc;
        if (dc + 1 > max) max = dc + 1;
    }
                        
    public int LongestConsecutive(TreeNode root) {
        if (root==null) return 0;
        max = 1;
        int ic, dc;
        Rec(root, out ic, out dc);
        
        return max;
    }
}


