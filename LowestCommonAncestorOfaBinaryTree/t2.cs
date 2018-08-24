/*
Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

Given the following binary search tree:  root = [3,5,1,6,2,0,8,null,null,7,4]

        _______3______
       /              \
    ___5__          ___1__
   /      \        /      \
   6      _2       0       8
         /  \
         7   4
Example 1:

Input: root, p = 5, q = 1
Output: 3
Explanation: The LCA of of nodes 5 and 1 is 3.
Example 2:

Input: root, p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself
             according to the LCA definition.

*/

// Comment: O(n). Other way is to add parent link and use depth.
// The below is to use simply boolean to see if any node or child node has p or q that are given.
// Only when two booleans are true -- we could apply this to n-array tree, set ans.
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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode ans = null;
        bool Rec(TreeNode n)
        {
            if (n==null) return false;
            bool sameRoot =  (n==p || n==q);
            bool left = Rec(n.left);
            bool right = Rec(n.right);
            
            if ((sameRoot && left) || (sameRoot && right) || (left && right))
                ans = n;
            return sameRoot || left || right;
        }
        Rec(root);
        
        return ans;
    }
}
