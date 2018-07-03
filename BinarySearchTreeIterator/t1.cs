/*
Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
*/
// Comment: Use a stack and pushing left childs.
/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class BSTIterator {
    Stack<TreeNode> s;
    public BSTIterator(TreeNode root) {
        s = new Stack<TreeNode>();
        if (root==null) return; // Spoiler: empty
        s.Push(root);
        root = root.left;
        while(root != null) {
            s.Push(root);
            root = root.left;
        }
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return s.Count != 0;
    }

    /** @return the next smallest number */
    public int Next() {
        var ret = s.Pop();
        var root = ret.right;
        while(root != null) {
            s.Push(root);
            root = root.left;
        }
        return ret.val;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */
