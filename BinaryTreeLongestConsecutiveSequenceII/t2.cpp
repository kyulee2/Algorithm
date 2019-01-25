/*
Given a binary tree, you need to find the length of Longest Consecutive Path in Binary Tree.

Especially, this path can be either increasing or decreasing. For example, [1,2,3,4] and [4,3,2,1] are both considered valid, but the path [1,2,4,3] is not valid. On the other hand, the path can be in the child-Parent-child order, where not necessarily be parent-child order.

Example 1:
Input:
        1
       / \
      2   3
Output: 2
Explanation: The longest consecutive path is [1, 2] or [2, 1].
Example 2:
Input:
        2
       / \
      1   3
Output: 3
Explanation: The longest consecutive path is [1, 2, 3] or [3, 2, 1].
Note: All the values of tree nodes are in the range of [-1e7, 1e7].
*/
// Comment: Read t1.cs first. t2.cpp is way simpler. Need to pass up with a pair (inc, dec) distance in the child node.
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
    pair<int, int> Rec(TreeNode* n) {
        if (!n) return make_pair(0,0);
        auto l = n->left;
        auto r= n->right;
        int inc = 1, dec = 1;
        pair<int,int> lp, rp;
        if (l) {
            lp = Rec(l);
            if (l->val+1 == n->val)
                inc = max(inc, lp.first + 1);
            if (l->val-1 == n->val)
                dec= max(dec, lp.second + 1);
        }

        if (r) {
            rp = Rec(r);
            if (r->val+1 == n->val)
                inc = max(inc, rp.first + 1);
            if (r->val-1 == n->val)
                dec= max(dec, rp.second + 1);
        }
        
        ans = max(ans, inc);
        ans = max(ans, dec);
        if (l&&r) {
            if (l->val+1 == n->val && r->val-1 == n->val)
                ans = max(ans, lp.first + rp.second + 1);
            if (l->val-1 == n->val && r->val+1 == n->val)
                ans = max(ans, lp.second + rp.first + 1);
        }
        
        return make_pair(inc, dec);
    }
    int longestConsecutive(TreeNode* root) {
        ans = 0;
        Rec(root);
        return ans;
    }
};
