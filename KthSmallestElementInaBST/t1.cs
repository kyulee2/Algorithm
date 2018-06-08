/*
Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.
Note: 
You may assume k is always valid, 1 = k = BST's total elements.
Example 1:
Input: root = [3,1,4,null,2], k = 1
   3
  / \
 1   4
  \
   2
Output: 1
Example 2:
Input: root = [5,3,6,2,4,null,null,1], k = 3
       5
      / \
     3   6
    / \
   2   4
  /
 1
Output: 3
Follow up:
What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?
*/

// Comment: Use a stack. Intialize stacking all left child.
// Implement next(). While consume a noew from stack. If right child exists, push all left childs of that right child recursively.
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
    Stack<TreeNode> s;
    int next()
    {        
        TreeNode c = s.Pop();
        if (c.right != null) {
            TreeNode r = c.right;
            s.Push(r);
            while(r.left != null) {
                s.Push(r.left);
                r = r.left;
            }
        }
        return c.val;            
    }
    
    public int KthSmallest(TreeNode root, int k) {
        s = new Stack<TreeNode>();
        s.Push(root);        
        TreeNode n = root;
        while(n.left != null) {
            s.Push(n.left);
            n = n.left;
        }        
        
        int small = 0;
        for(int i=0; i<k; i++)
            small =next();
        return small;
    }
}
