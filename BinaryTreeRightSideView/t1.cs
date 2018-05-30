/*
Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
Example:
Input: [1,2,3,null,5,null,4]
Output: [1, 3, 4]
Explanation:

   1            <---
 /   \
2     3         <---
 \     \
  5     4       <---
*/

// Comment: Similar to print tree in row. Just take the last one which is right before nil(next line)

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
    public IList<int> RightSideView(TreeNode root) {
        List<int> ans = new List<int>();
        if (root==null) return ans;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        TreeNode nil = new TreeNode(0);
        q.Enqueue(nil);
        while(q.Count != 0) {
            TreeNode n = q.Dequeue();
            if (n==nil) {
                if (q.Count != 0) q.Enqueue(nil);
                continue;
            }
            if (q.Peek() == nil)
                ans.Add(n.val);
            TreeNode l = n.left;
            TreeNode r = n.right;
            if (l!=null) q.Enqueue(l);
            if (r!=null) q.Enqueue(r);
        }
        return ans;
    }
}
