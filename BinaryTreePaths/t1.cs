/*
Given a binary tree, return all root-to-leaf paths.
Note: A leaf is a node with no children.
Example:
Input:

   1
 /   \
2     3
 \
  5

Output: ["1->2->5", "1->3"]

Explanation: All root-to-leaf paths are: 1->2->5, 1->3
*/
// Comment: Easy.
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
    List<string> ans;
    void Rec(TreeNode n, String s)
    {
        TreeNode l = n.left;
        TreeNode r = n.right;
        s += n.val.ToString();
        if (l==null && r==null) {
            ans.Add(s);
            return;
        }
        s += "->";
        if (l!=null)
            Rec(l, s);
        if (r!=null)
            Rec(r, s);
    }
    public IList<string> BinaryTreePaths(TreeNode root) {
        ans = new List<string>();
        if (root==null) return ans;
        Rec(root, "");
        return ans;
    }
}

