/*
Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.
Note:
Given target value is a floating point.
You may assume k is always valid, that is: k = total nodes.
You are guaranteed to have only one unique set of k values in the BST that are closest to the target.
Example:
Input: root = [4,2,5,1,3], target = 3.714286, and k = 2

    4
   / \
  2   5
 / \
1   3

Output: [4,3]
Follow up:
Assume that the BST is balanced, could you solve it in less than O(n) runtime (where n = total nodes)?

*/
// Comment: Tricky. Use two stacks. The key idea is to record predecessor stack when moving right
// When moving left, record node in successor stack. 
// O(k log n) time. O(k) space
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
    public IList<int> ClosestKValues(TreeNode root, double target, int k) {
       
        var sp = new Stack<TreeNode>(); // stack for predecessor
        var ss = new Stack<TreeNode>(); // stack for successor
        void InitStack(TreeNode r)
        {
            if (r==null) return;
            if (r.val == target) {
                sp.Push(r);
                ss.Push(r);
            }
            else if (r.val < target) {
                sp.Push(r); // when moving right: record it to predecessor stack
                InitStack(r.right);
            }
            else if (r.val>target) {
                ss.Push(r); // when moving left: record it to successor stack
                InitStack(r.left);
            }
        }
        
        TreeNode GetPred()
        {
            if (sp.Count==0) return null;
            TreeNode curr = sp.Pop();
            var ret = curr;
            curr = curr.left;
            while(curr != null) {
                sp.Push(curr);
                curr = curr.right;
            }
            return ret;
        }
        
        TreeNode GetSucc()
        {
            if (ss.Count==0) return null;
            TreeNode curr = ss.Pop();
            var ret = curr;
            curr = curr.right;
            while(curr != null) {
                ss.Push(curr);
                curr = curr.left;
            }
            return ret;
        }
        
        // main recursion
        var ans = new List<int>();
        if (k<=0 || root==null) return ans;     
        InitStack(root);

        while(k>0) {
            var left = GetPred();
            var right = GetSucc();
            if (left!= null && right==null) {
                ans.Add(left.val);
                k--;
            }
            else if (left==null && right!= null) {
                ans.Add(right.val);
                k--;
            }
            else {
                if (left==right) {
                    ans.Add(left.val);
                    k--;
                    continue;
                }
                k-= 2;
                if (Math.Abs(target-left.val) < Math.Abs(target-right.val)) {
                    ans.Add(left.val);
                    if (k>=0) ans.Add(right.val);
                } else {
                    ans.Add(right.val);
                    if (k>=0) ans.Add(left.val);
                }
            }
        }

        return ans;
    }
}