/*
Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

Search for a node to remove.
If the node is found, delete the node.
Note: Time complexity should be O(height of tree).

Example:

root = [5,3,6,2,4,null,7]
key = 3

    5
   / \
  3   6
 / \   \
2   4   7

Given key to delete is 3. So we find the node with value 3 and delete it.

One valid answer is [5,4,6,2,null,null,7], shown in the following BST.

    5
   / \
  4   6
 /     \
2       7

Another valid answer is [5,2,6,null,4,null,7].

    5
   / \
  2   6
   \   \
    4   7
*/
// Comment: When two children exist, need to replace the current node with the inorder next order
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
    TreeNode SearchParent(TreeNode n, int k)
    {
        if (n.left != null && n.left.val == k)
            return n;
        if (n.right != null && n.right.val == k)
            return n;
        if (k <n.val && n.left != null)
            return SearchParent(n.left, k);
        if (k >=n.val && n.right != null)
            return SearchParent(n.right, k);
        return null;
    }
    void Splice(TreeNode p, bool isRight, TreeNode c)
    {
        var cl = c.left;
        var cr = c.right;
        
        // leaf node
        if (cl == null && cr == null) {
            if (isRight) p.right = null;
            else p.left = null;
            return;
        }
        // one child
        if (cl==null && cr != null) {
            if (isRight) p.right = cr;
            else p.left = cr;
            return;
        }
        if (cr==null && cl != null) {
            if (isRight) p.right = cl;
            else p.left = cl;
            return;
        }
        
        // two children.
        // Find the next inorder element
        if (cr.left == null) {
            // no grand left child of right child
            // just hoist the right child itself to current
            cr.left = c.left;
            
            if (isRight) p.right = cr;
            else p.left = cr;
        } else {
            var nextp = cr;
            var curr = nextp.left;
            while(curr.left != null) {
                nextp = curr;
                curr = curr.left;
            }
            nextp.left = curr.right;

            // clone left/right from c node
            curr.left = cl;
            curr.right = cr;
            
            if (isRight) p.right = curr;
            else p.left = curr;
        }
    }
    
    public TreeNode DeleteNode(TreeNode root, int key) {
        TreeNode dummy = new TreeNode(Int32.MinValue);
        dummy.right = root;
        var p = SearchParent(dummy, key);
        if (p==null) return root; // no valid key
        if (p.left != null && p.left.val == key)
            Splice(p, false, p.left);
        else Splice(p, true, p.right);
        
        return dummy.right;
    }
}
