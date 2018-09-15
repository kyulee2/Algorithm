/*
Consider all the leaves of a binary tree.  From left to right order, the values of those leaves form a leaf value sequence.

For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
Two binary trees are considered leaf-similar if their leaf value sequence is the same.
Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
 
Note:
Both of the given trees will have between 1 and 100 nodes.
*/
// Comment: O(n) time, O(n) space. Try with O(1) space by iterating/finding the next leaf node.
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        var ans1 = new List<int>();
        var ans2 = new List<int>();
        if (root1==null && root2==null)
            return true;
        if (root1==null && root2!=null)
            return false;
        if (root1!=null && root2==null)
            return false;
        void Rec(TreeNode n, List<int> s)
        {
            if (n.left != null)
                Rec(n.left, s);
            if (n.left ==null && n.right==null) // leaf
                s.Add(n.val);
            if (n.right != null)
                Rec(n.right, s);
        }
        Rec(root1, ans1);
        Rec(root2, ans2);
        if (ans1.Count != ans2.Count)
            return false;
        for(int i=0; i<ans1.Count; i++)
            if (ans1[i] != ans2[i])
                return false;
        
        return true;
    }
}
