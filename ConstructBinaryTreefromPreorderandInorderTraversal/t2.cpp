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
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    TreeNode* rec(vector<int>& preorder, vector<int>& inorder, int i, int j, int k, int l)
    {
        if (i>j) return 0;
        if (i==j) return new TreeNode(preorder[i]);
        auto ans = new TreeNode(preorder[i]);
        int ink = k;
        int prei = i;
        while(k<=l && inorder[k]!= ans->val) {k++; i++;}
        ans->left = rec(preorder, inorder, prei+1 ,i ,ink, k-1);
        ans->right = rec(preorder, inorder, i+1, j,k+1, l);
        return ans;
    }
    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
        int size = preorder.size();
        if (size==0) return 0;
        return rec(preorder, inorder, 0, size-1, 0,size-1);
    }
};
