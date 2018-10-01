/*
You are given a binary tree in which each node contains an integer value.

Find the number of paths that sum to a given value.

The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

Example:

root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8

      10
     /  \
    5   -3
   / \    \
  3   2   11
 / \   \
3  -2   1

Return 3. The paths that sum to 8 are:

1.  5 -> 3
2.  5 -> 2 -> 1
3. -3 -> 11
*/
// Comment: Strightfoward. O(nd). There is  a better one O(n). The below is not optimal though it's passed.
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
    public int PathSum(TreeNode root, int sum) {
        int ans = 0;
        void Rec(TreeNode n, List<int> parents)
        {
            if (n==null) return;

            var next = new List<int>();
            foreach(var p in parents)
                next.Add(p + n.val);
            next.Add(n.val);
            
            foreach(var p in next) {
                if (p == sum)
                    ans++;
            }
            Rec(n.left, next);
            Rec(n.right, next);
        }
        
        Rec(root, new List<int>());
        return ans;
    }
}
