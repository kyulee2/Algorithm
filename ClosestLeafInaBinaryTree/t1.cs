/*
Given a binary tree where every node has a unique value, and a target key k, find the value of the nearest leaf node to target k in the tree.

Here, nearest to a leaf means the least number of edges travelled on the binary tree to reach any leaf of the tree. Also, a node is called a leaf if it has no children.

In the following examples, the input tree is represented in flattened form row by row. The actual root tree given will be a TreeNode object.

Example 1:

Input:
root = [1, 3, 2], k = 1
Diagram of binary tree:
          1
         / \
        3   2

Output: 2 (or 3)

Explanation: Either 2 or 3 is the nearest leaf node to the target of 1.
Example 2:

Input:
root = [1], k = 1
Output: 1

Explanation: The nearest leaf node is the root node itself.
Example 3:

Input:
root = [1,2,3,4,null,null,null,5,null,6], k = 2
Diagram of binary tree:
             1
            / \
           2   3
          /
         4
        /
       5
      /
     6

Output: 3
Explanation: The leaf node with value 3 (and not the leaf node with value 6) is nearest to the node with value 2.
Note:
root represents a binary tree with at least 1 node and at most 1000 nodes.
Every node has a unique node.val in range [1, 1000].
There exists some node in the given binary tree for which node.val == k.
*/
// Comment: Traverse backward and forward to update minimal distance from leaf
// O(n) for time and space
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
    public int FindClosestLeaf(TreeNode root, int k) {
        var map = new Dictionary<int, int[]>(); // node : [dist, leafnode]
        // backward -- bottom-up
        if (root==null) return -1;
        int[] Rec(TreeNode n)
        {
            var l = n.left;
            var r = n.right;
            if (l==null && r==null) {
                map[n.val] = new int[2]{0, n.val};
            } else if (l==null && r!=null) {
                var t = Rec(r);
                map[n.val] = new int[2]{t[0]+1, t[1]};
            } else if (l!=null && r==null) {
                var t = Rec(l);
                map[n.val] = new int[2]{t[0]+1, t[1]};
            } else {
                var t1 = Rec(r);
                var t2 = Rec(l);
                map[n.val] = t1[0]<t2[0] ? new int[2]{t1[0]+1, t1[1]}
                : new int[2]{t2[0]+1, t2[1]};
            }
            return map[n.val];
        }
        
        // Forward while updating map
        int ans = -1;
        void RecFor(TreeNode n, int dist, int leaf)
        {
            if (dist != -1) {
                var t = map[n.val];
                if (dist < t[0]) {
                    t[0] = dist;
                    t[1] = leaf;
                }
            }
            dist = map[n.val][0];
            leaf = map[n.val][1];
            if (n.val == k) {
                ans = leaf;
                return;
            }
            if (n.left != null)
                RecFor(n.left, dist + 1, leaf);
            if (n.right != null)
                RecFor(n.right, dist + 1, leaf);
        }
        
        Rec(root);
        RecFor(root, -1, -1);
        
        return ans;
    }
}
