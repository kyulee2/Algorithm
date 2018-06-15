/*
Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.
Two trees are duplicate if they have the same structure with same node values.
Example 1: 
        1
       / \
      2   3
     /   / \
    4   2   4
       /
      4
The following are two duplicate subtrees:
      2
     /
    4
and
    4
Therefore, you need to return above trees' root in the form of a list.
*/
// Comment: Initially, I just use a map val to node, and create isMatch function. For each node visit, check to see if there is a node in map that matches. This leads to time-out.
// A bit more chnage. Record level summary/depth as well shown below. val -> depth -> node.
// I think building string representing tree-structure and cacheing it for matching comparison.
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
    Dictionary<int, Dictionary<int, List<TreeNode>>> map;
    HashSet<TreeNode> ans;
    bool isMatch(TreeNode x, TreeNode y)
    {
        if (x==null && y==null) return true;
        if (x==null && y!=null) return false;
        if (x!=null && y==null) return false;
        if (x.val != y.val) return false;
        return isMatch(x.left, y.left) && isMatch(x.right, y.right);
    }
    
    int Rec(TreeNode n)
    {
        if (n==null) return 0;
        int val = n.val;
        int l  = Rec(n.left);
        int r = Rec(n.right);
        int depth = Math.Max(l, r) + 1;
        if (!map.ContainsKey(val)) {
            var d = new Dictionary<int, List<TreeNode>>();
            map[val] = d;
        }
        
        if (!map[val].ContainsKey(depth)) {
            var ll = new List<TreeNode>();
            map[val][depth] = ll;
            ll.Add(n);
            return depth;
        }

        foreach(var o in map[val][depth])
           if (isMatch(o, n)) {
               ans.Add(o);
               return depth;
           }
        
        map[val][depth].Add(n);
        return depth;
    }
    
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        // Init data
        map = new Dictionary<int, Dictionary<int, List<TreeNode>>>();
        ans = new HashSet<TreeNode>();
        
        // Main rec
        Rec(root);
        
        return ans.ToList();
    }
}


