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

// Comment: I recall there is a better solution O(n).
// The below uses two HashSet. On found, record it to each HashSet.
// Then propagate back to parent if child is in the Set.
// The parent that first meets/finds itself in the HashSet, it's the answer.
// If we're allowed to modify TreeNode, we could bookkeep such stats in place.
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
    TreeNode ans;
    HashSet<TreeNode> pPar;
    HashSet<TreeNode> qPar;
    void Rec(TreeNode r, TreeNode p, TreeNode q) {
        if (r==null) return;
        if (r == p) pPar.Add(r);
        if (r == q) qPar.Add(r);
        Rec(r.left, p, q);
        Rec(r.right, p, q);
        // Propagate child's parent to root's parent
        if (pPar.Contains(r.left)) pPar.Add(r);
        if (qPar.Contains(r.left)) qPar.Add(r);
        if (pPar.Contains(r.right)) pPar.Add(r);
        if (qPar.Contains(r.right)) qPar.Add(r);
        if (pPar.Contains(r) && qPar.Contains(r) && ans == null) {
            // The first found is the answer
            ans = r;
        }
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        pPar = new HashSet<TreeNode>();
        qPar = new HashSet<TreeNode>();
        ans = null;
        Rec(root, p, q);
        return ans;
    }
}

