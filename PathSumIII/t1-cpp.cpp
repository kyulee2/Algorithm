/*
You are given a binary tree in which each node contains an integer value.

Find the number of paths that sum to a given value.

The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

Example:

root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8

      10
     /  \
    5   -3
   / \    \
  3   2   11
 / \   \
3  -2   1

Return 3. The paths that sum to 8 are:

1.  5 -> 3
2.  5 -> 2 -> 1
3. -3 -> 11
*/
// Comment: Use a map to track prefix sum and its count. It's interesting.
// O(n) space and time
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
    unordered_map<int,int> s;
    int Rec(TreeNode* n, int curr, int target)
    {
        if (!n) return 0;
        curr += n->val;

        int sum = 0;
        if (s.find(curr-target)!=s.end())
            sum+= s[curr-target];
        ++s[curr];
        
        sum += Rec(n->left, curr, target);
        sum += Rec(n->right, curr, target);
        
        --s[curr];
        return sum;
    }
    int pathSum(TreeNode* root, int sum) {
        s[0] = 1;
        return Rec(root, 0, sum);
    }
};
