/*
Given inorder and postorder traversal of a tree, construct the binary tree.
Note:
You may assume that duplicates do not exist in the tree.
For example, given
inorder = [9,3,15,20,7]
postorder = [9,15,7,20,3]
Return the following binary tree:
    3
   / \
  9  20
    /  \
   15   7
*/
// comment: key point is to find root position in inorder whose element is same as the end of post
// Split two vectors in the follow way:
// in:   lll N rrrr
// post: lll rrrr N
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
    TreeNode* Rec(vector<int>& in, vector<int>& post, int i, int j, int p, int q) {
        if (i>j) return nullptr;
        if (i==j) return new TreeNode(in[i]);
        auto n = post[q];
        int curr = i;
        while(in[curr] != n) curr++;
        auto ans = new TreeNode(n);
        ans->left = Rec(in, post, i, curr-1, p, p+curr-i-1);
        ans->right = Rec(in, post, curr+1, j, p+curr-i, q-1);
        return ans;
    }
    TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) {
        int len = inorder.size();
        if (!len) return nullptr;
        return Rec(inorder, postorder, 0, len-1, 0, len-1);
    }
};