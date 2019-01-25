/*
Reverse a linked list from position m to n. Do it in one-pass.
Note: 1 = m = n = length of list.
Example:
Input: 1->2->3->4->5->NULL, m = 2, n = 4
Output: 1->4->3->2->5->NULL
*/
// Comment: Use dummy. Track prev, curr, fast.
// reverse betwee curr to fast, and splice them
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
    ListNode* reverseBetween(ListNode* head, int m, int n) {
        if (!head) return nullptr;
        ListNode dummy(0);
        dummy.next = head;
        auto prev = &dummy;
        auto curr = head;
        
        int d  = n- m; // assert n >m
        // move prev,curr by m 
        while(m>1) {
            prev = prev->next;
            curr = curr->next;
            m--;
        }

        auto fast = curr;
        while(d>0) {
            fast = fast->next;
            d--;
        }

        // reverse m-n list
        auto oldPrev = prev;
        if (!fast) 
            prev = nullptr;
        else {
            prev = fast->next; // splice prev = 5 (fast->next)
            fast->next = nullptr;
        }
        while(curr) {
            auto next2 = curr->next;
            curr->next = prev;
            prev = curr;
            curr = next2;
        }

        // splice oldPrev to new head (4)
        oldPrev->next = prev;
        
        
        return dummy.next;
    }
};