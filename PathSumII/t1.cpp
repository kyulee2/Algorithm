/*
Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
Note: A leaf is a node with no children.
Example:
Given the below binary tree and sum = 22,
      5
     / \
    4   8
   /   / \
  11  13  4
 /  \    / \
7    2  5   1
Return:
[
   [5,4,11,2],
   [5,8,4,5]
]
*/
// Comment: Bail out null node in Rec, and check target sum on both childs are null.
// Otherwise, duplicated answers from each null node of left and right.
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
    vector<vector<int>> ans;
    vector<int> t;
    int target;
    void Rec(TreeNode* n, int curr) {
        curr += n->val;
        t.push_back(n->val);
        auto l = n->left;
        auto r= n->right;
        if (!l && !r) {
            if (curr==target)
                ans.push_back(t);
            t.pop_back();
            return;
        }
        if (l)
            Rec(l, curr);
        if (r)
            Rec(r, curr);
        t.pop_back();
    }
    
    vector<vector<int>> pathSum(TreeNode* root, int sum) {
        target= sum;
        if (!root)
            return ans;

        Rec(root, 0);
        return ans;
    }
};