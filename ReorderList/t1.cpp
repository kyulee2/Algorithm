/*
Given a singly linked list L: L0?L1?…?Ln-1?Ln,
reorder it to: L0?Ln?L1?Ln-1?L2?Ln-2?…
You may not modify the values in the list's nodes, only nodes itself may be changed.
Example 1:
Given 1->2->3->4, reorder it to 1->4->2->3.
Example 2:
Given 1->2->3->4->5, reorder it to 1->5->2->4->3.
*/
// Comment: Good example to pratice list
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
    void reorderList(ListNode* head) {
        // Spoiler: bailout 0 or 1 element
        if (!head) return;
        if (!head->next)
            return;
        
        // split
        ListNode dummy(0);
        dummy.next = head;
        auto prev = &dummy;
        auto curr = prev;
        auto fast = head;
        while(fast) {
            curr = curr->next;
            fast = fast->next;
            if (!fast) {
                break;
            }
            fast = fast->next;
        }
        
        auto latter = curr->next;
        prev = nullptr;
        curr->next= nullptr;
        // reverse the latter
        while(latter) {
            auto next = latter->next;
            latter->next = prev;
            prev = latter;
            latter = next;
        }
        
        latter = prev;
        curr = head;
        // splice
        while(latter) {
            auto next = latter->next;
            auto currnext = curr->next;
            curr->next = latter;
            latter->next = currnext;
            curr = currnext;
            latter = next;
        }

    }
};
