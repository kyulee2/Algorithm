/*
Given a binary tree, return the vertical order traversal of its nodes' values. (ie, from top to bottom, column by column).
If two nodes are in the same row and column, the order should be from left to right.
Examples 1:
Input: [3,9,20,null,null,15,7]

   3
  /\
 /  \
 9  20
    /\
   /  \
  15   7 

Output:

[
  [9],
  [3,15],
  [20],
  [7]
]
Examples 2:
Input: [3,9,8,4,0,1,7]

     3
    /\
   /  \
   9   8
  /\  /\
 /  \/  \
 4  01   7 

Output:

[
  [4],
  [9],
  [3,0,1],
  [8],
  [7]
]
Examples 3:
Input: [3,9,8,4,0,1,7,null,null,null,2,5] (0's right child is 2 and 1's left child is 5)

     3
    /\
   /  \
   9   8
  /\  /\
 /  \/  \
 4  01   7
    /\
   /  \
   5   2

Output:

[
  [4],
  [9,5],
  [3,0,1],
  [8,2],
  [7]
]
*/
// Comment: A bit interesting. Ordered by left/right increment (for column).
// There is spoiler (see below), we also need to order them by recursion depth (for Row).
// The bottom one has another solution using BFS -- the recursion order is enforced by itself
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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var ans = new List<IList<int>>();
        // Spoiler: Using one level map fails: 201 / 212 
        // For the same column, should order for row (recursion depth)
        // var map = new Dictionary<int, List<int>>();
        var map = new Dictionary<int, List<int[]>>();
        void Rec(TreeNode n, int d, int r) {
            if (n==null) return;
            int val = n.val;
            if (!map.ContainsKey(d))
                map[d] = new List<int[]>();
            map[d].Add(new int[]{val,r});
            
            Rec(n.left, d - 1, r + 1);
            Rec(n.right, d + 1, r + 1);
        }
        
        // main Recursion
        Rec(root, 0, 0);
        
        // Sort keys
        var l = map.Keys.ToList();
        l.Sort();
        
        foreach(var k in l) {
            map[k].Sort((x,y) => (x[1] - y[1]));
            var t = new List<int>();
            foreach(var val in map[k]) {
                t.Add(val[0]);
            }
            ans.Add(t);
        }
        return ans;
    }
}

// Another one
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
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        // BFS enforces the depth order.. Just consider left/right column order
        var map = new Dictionary<int, List<int>>();
        var q = new Queue<Tuple<TreeNode, int>>();
        var ans = new List<IList<int>>();
        if (root==null) return ans;
        
        // Build map by BFS
        var rt = new Tuple<TreeNode, int>(root, 0);
        q.Enqueue(rt);
        while(q.Count != 0) {
            var nt = q.Dequeue();
            var n = nt.Item1;
            var c = nt.Item2;
            if (!map.ContainsKey(c))
                map[c] = new List<int>();
            map[c].Add(n.val);
            if (n.left != null)
                q.Enqueue(new Tuple<TreeNode, int>(n.left, c-1));
            if (n.right != null)
                q.Enqueue(new Tuple<TreeNode, int>(n.right, c+1));
        }
        
        // Postprocess map
        var l = map.Keys.ToList();
        l.Sort();
        foreach(var k in l)
            ans.Add(map[k]);
        return ans;
    }
}


