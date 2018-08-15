/*
Given preorder and inorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.

For example, given

preorder = [3,9,20,15,7]
inorder = [9,3,15,20,7]
Return the following binary tree:

    3
   / \
  9  20
    /  \
   15   7
*/
// Comment: Interesting. For given split point, recursion left and right respectively
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int len = preorder.Length;
        TreeNode Rec(int i, int j, int x, int y) {
            if (i>j) return null;
            
            TreeNode r = new TreeNode(preorder[i]);
            
            // Find split point in inorder
            int k = x;
            for(; k<=y; k++)
                if (preorder[i] == inorder[k])
                    break;
            
            int delta = k - x; // distance from x in inorder
            r.left = Rec(i+1, i+delta, x, k-1);
            r.right = Rec(i+delta+1, j, k+1, y);
            
            return r;
        }
        
        return Rec(0, len-1, 0, len-1);
    }
}
