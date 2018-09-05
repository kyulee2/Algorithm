/*
Given a binary tree, write a function to get the maximum width of the given tree. The width of a tree is the maximum width among all levels. The binary tree has the same structure as a full binary tree, but some nodes are null. 
The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.
Example 1:
Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
Example 2:
Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).
Example 3:
Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).
Example 4:
Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).


Note: Answer will in the range of 32-bit signed integer. 
*/
// Comment: Think about encoding min/max of id at each level.
// When depth increases, shift id(sum) by 1 and add 0 to left or 1 to right.
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
    public int WidthOfBinaryTree(TreeNode root) {
        if (root==null) return 0;
        int max = 1;
        var map = new Dictionary<int, int[]>();
        void Rec(TreeNode n, int d, int s) {
            if (n==null) return;
            if (!map.ContainsKey(d))
                map[d] = new int[2]{Int32.MaxValue, Int32.MinValue};
            var t = map[d];
            t[0] = Math.Min(t[0], s);
            t[1] = Math.Max(t[1], s);
            max = Math.Max(max, t[1] - t[0] + 1);
            
            Rec(n.left, d+1, s<<1);
            Rec(n.right, d+1, (s<<1)|1);
        }
        
        Rec(root, 0, 0);
        return max;
    }
}
