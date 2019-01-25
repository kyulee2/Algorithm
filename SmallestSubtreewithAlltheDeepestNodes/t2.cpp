/*
Given a binary tree rooted at root, the depth of each node is the shortest distance to the root.
A node is deepest if it has the largest depth possible among any node in the entire tree.
The subtree of a node is that node, plus the set of all descendants of that node.
Return the node with the largest depth such that it contains all the deepest nodes in its subtree.
 
Example 1:
Input: [3,5,1,6,2,0,8,null,null,7,4]
Output: [2,7,4]
Explanation:



We return the node with value 2, colored in yellow in the diagram.
The nodes colored in blue are the deepest nodes of the tree.
The input "[3, 5, 1, 6, 2, 0, 8, null, null, 7, 4]" is a serialization of the given tree.
The output "[2, 7, 4]" is a serialization of the subtree rooted at the node with value 2.
Both the input and output have TreeNode type.
 
Note:
The number of nodes in the tree will be between 1 and 500.
The values of each node are unique.
*/
// Comment: O(n) time and space. Two passes unlike c1.cs. So a bit less efficient, but easier to understand.
// Get deepest nodes and record them in set. In the second path, as soon as all deepest nodes are found, update answer.
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
    set<TreeNode*> s;
    int max = -1;
    // build s and max
    void Rec(TreeNode* n, int d) {
        if (!n) return;
        if (d>max) {
            max = d;
            s.clear();
            s.insert(n);
        } else if (d==max) {
            s.insert(n);
        }
        Rec(n->left, d+1);
        Rec(n->right, d+1);
    }
    
    TreeNode* ans = nullptr;
    int Rec2(TreeNode *n) {
        if (!n) return 0;
        auto l = Rec2(n->left);
        auto r = Rec2(n->right);
        int cnt = 0;
        if (s.find(n) != s.end()) cnt++;
        cnt += l + r;
        if (cnt == s.size()) { // first found all depest child
            ans = n;
            cnt = 0; // reset it so that we won't update ans
        }
        return cnt;
    }
    
    TreeNode* subtreeWithAllDeepest(TreeNode* root) {
        Rec(root,0);

        Rec2(root);
        return ans;
    }
};