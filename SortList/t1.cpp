/*
Sort a linked list in O(n log n) time using constant space complexity.
Example 1:
Input: 4->2->1->3
Output: 1->2->3->4
Example 2:
Input: -1->5->3->4->0
Output: -1->0->3->4->5
*/
// Comment: handle corner cases
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
    ListNode* sortList(ListNode* head) {
        if (!head) return nullptr;
        if (!head->next) return head; // spoiler
        
        ListNode dummy(0);
        auto prev = &dummy;
        prev->next = head;
        auto curr = head;
        while(curr) {
            prev= prev->next;
            curr = curr->next;
            if (!curr) break;
            curr = curr->next;
             
        }

        auto half = prev->next;
        prev->next = nullptr;
        auto l = sortList(head);
        auto r= sortList(half);

        curr = &dummy;
        while(l&&r) {
            if (l->val < r->val) {
                curr->next = l;
                curr = l;
                l = l->next;
            } else {
                curr->next = r;
                curr = r;
                r = r->next;
            }
        }
        if (l) curr->next = l;
        if (r) curr->next = r;
        
        return dummy.next;
    }
};