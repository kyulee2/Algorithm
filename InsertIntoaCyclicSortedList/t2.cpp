/*
Given a node from a cyclic linked list which is sorted in ascending order, write a function to insert a value into the list such that it remains a cyclic sorted list. The given node can be a reference to any single node in the list, and may not be necessarily the smallest value in the cyclic list.
If there are multiple suitable places for insertion, you may choose any place to insert the new value. After the insertion, the cyclic list should remain sorted.
If the list is empty (i.e., given node is null), you should create a new single cyclic list and return the reference to that single node. Otherwise, you should return the original given node.
The following example may help you understand the problem better:
 


In the figure above, there is a cyclic sorted list of three elements. You are given a reference to the node with value 3, and we need to insert 2 into the list.
 
 
 


The new node should insert between node 1 and node 3. After the insertion, the list should look like this, and we should still return node 3.
*/
// Comment: Use prev, curr to find insertion point (1)
// Other way is to find max. Handle special case earlier and do the normal case later.
/*
// Definition for a Node.
class Node {
public:
    int val;
    Node* next;

    Node() {}

    Node(int _val, Node* _next) {
        val = _val;
        next = _next;
    }
};
*/
class Solution {
public:
    Node* insert(Node* head, int insertVal) {
        if (!head) {
            Node* r = new Node(insertVal, nullptr);
            r->next = r;
            return r;
        }
        
        auto ans = head;
        auto prev = head;
        auto curr = prev->next;  
        while(curr != head) {
            int p = prev->val;
            int c = curr->val;
            if (p<=c) { // normal case:  min <= val <= max
                if (p<= insertVal && insertVal <=c) {
                    prev->next = new Node(insertVal, curr);
                    return ans;
                }
            } else {  // edge case: val<=min or val>=max
                if (insertVal <=c || insertVal >= p) {
                    prev->next = new Node(insertVal, curr);
                    return ans;
                }
            }
            prev = curr;
            curr = curr->next;
        }
        
        prev->next  = new Node(insertVal, curr);
        return ans;
    }
};

// Other solution (2) a bit longer, though
class Solution {
public:
    Node* insert(Node* head, int insertVal) {
        if (!head) {
            Node* r = new Node(insertVal, nullptr);
            r->next = r;
            return r;
        }
        
        // Find max node
        auto ans = head;
        auto curr = head->next;
        auto max = head;
        while(curr != ans) {
            if (curr->val > max->val)
                max = curr;
            curr = curr->next;
        }
        // Set min after max
        auto min = max->next;
        
        // corner case: insert it between tail (max) and head (min)
        if (insertVal >= max->val || insertVal <= min->val) {
            max->next = new Node(insertVal, min);
            return ans;
        }

        // normal case where  min < val  < max
        auto prev = min;
        curr = min->next;        
        while(prev != max) {
            if (prev->val<= insertVal && insertVal <=curr->val) {
                prev->next = new Node(insertVal, curr);
                break;
            }
            prev = curr;
            curr = curr->next;
        }
        
        return ans;
    }
};
