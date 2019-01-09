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
// The below replace the value of the current node with the largest (in-order) value of the left child.
// Note when deleting such target node, preserve its left child
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
    void Rec(TreeNode *p, TreeNode *n, int key) {
        // spoiler: not found case
        if (!n) return; // do not anything
        
        if (n->val <key)
            Rec(n, n->right, key);
        else if (n->val > key)
            Rec(n, n->left, key);
        else {
            auto l = n->left;
            auto r = n->right;
            if (!l && !r) {
                if (p->left == n) p->left = nullptr;
                else p->right = nullptr;
                delete n;
            } else if (l && !r) {
                if (p->left == n) p->left = l;
                else p->right = l;
                delete n;
            } else if (!l && r) {
                if (p->left == n) p->left = r;
                else p->right = r;
                delete n;
            } else { // two childrens
                // Either find the next largest of left or the smallest of right child
                auto curr = n; // curr is the parent of target to splice new childs(left)
                auto target = n->left;
                while(target->right) { // keep finding the right child to find the next order
                    curr = target;
                    target = target->right;
                }
                // replace the n value with the target
                n->val = target->val;
                if (curr->left == target) curr->left = target->left; /* spoiler: use left chid*/
                else curr->right = target->left; /* spoiler: use left chid*/
                delete target;
            }
        }
    }
    TreeNode* deleteNode(TreeNode* root, int key) {
        TreeNode dummy(0);
        dummy.right = root;
        Rec(&dummy, root, key);
        return dummy.right;
    }
};