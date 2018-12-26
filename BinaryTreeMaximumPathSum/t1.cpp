/*
Given a non-empty binary tree, find the maximum path sum.

For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The path must contain at least one node and does not need to go through the root.

Example 1:

Input: [1,2,3]

       1
      / \
     2   3

Output: 6
Example 2:

Input: [-10,9,20,null,null,15,7]

   -10
   / \
  9  20
    /  \
   15   7

Output: 42
*/
// Comment: Good example to practice tree. O(n). Consider how to get/update max/ans and what to pass over to parent.
// max is updated either curr, curr+left, curr+right, or curr+left+right
// The pass over to parent is either curr, curr+left, or curr+right
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    int ans;
    int Rec(TreeNode* root) {
        int left = root->left ? Rec(root->left) :0;
        int right = root->right ? Rec(root->right) : 0;
        int curr = root->val;
        int p = max(max(left+curr, right+curr), curr);
        ans = max(ans, max(p, left + right + curr));
        return p;
    }
    int maxPathSum(TreeNode* root) {
        ans = INT_MIN;
        Rec(root);
        return ans;
    }
};
