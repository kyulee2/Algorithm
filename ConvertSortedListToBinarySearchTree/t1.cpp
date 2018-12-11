/*
Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
Example:
Given the sorted linked list: [-10,-3,0,5,9],

One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

      0
     / \
   -3   9
   /   /
 -10  5
*/
// Comment: Not hard, but tricky to get the split point (half).
// We need prev of half. In below, curr starts with dummy while fast starts with head.

/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
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
    ListNode *dummy = new ListNode(1);
    ListNode* split(ListNode *h) {
        dummy->next = h;
        ListNode *curr = dummy, *fast = h;
        while(fast) {
            fast = fast->next;
            if (fast==nullptr)
                return curr;
            fast = fast->next;
            if (fast==nullptr)
                return curr;
            curr = curr->next;
        }
        return curr;
    }
    
    TreeNode* sortedListToBST(ListNode* head) {
        if (head==nullptr)  return nullptr;
        auto prev = split(head);
        //printf("%d\n", prev->val);
        auto ans = new TreeNode(prev->next->val);
        auto next = prev->next->next;
        prev->next = nullptr;
        ans->left = prev == dummy ? nullptr : sortedListToBST(head);
        ans->right = sortedListToBST(next);
        return ans;
    }
};