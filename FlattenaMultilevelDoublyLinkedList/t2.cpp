/*
Pick One

You are given a doubly linked list which in addition to the next and previous pointers, it could have a child pointer, which may or may not point to a separate doubly linked list. These child lists may have one or more children of their own, and so on, to produce a multilevel data structure, as shown in the example below.
Flatten the list so that all the nodes appear in a single-level, doubly linked list. You are given the head of the first level of the list.
Example:
Input:
 1---2---3---4---5---6--NULL
         |
         7---8---9---10--NULL
             |
             11--12--NULL

Output:
1-2-3-7-8-11-12-9-10-4-5-6-NULL
Explanation for the above example:
Given the following multilevel doubly linked list:

We should return the following flattened doubly linked list:



Seen this question in a real interview before?  YesNo

Difficulty:
Medium
*/
// Comment: Just be careful. Recursion returns the non-null lastnode from the child.
// Splice them to curren't next node.
/*
// Definition for a Node.
/*
// Definition for a Node.
class Node {
public:
    int val = NULL;
    Node* prev = NULL;
    Node* next = NULL;
    Node* child = NULL;

    Node() {}

    Node(int _val, Node* _prev, Node* _next, Node* _child) {
        val = _val;
        prev = _prev;
        next = _next;
        child = _child;
    }
};
*/
class Solution {
public:
    Node* Rec(Node* head) {
        if (!head) return nullptr;

        auto child = head->child;
        auto left = Rec(head->child);
        head->child = nullptr;
        auto next = head->next;
        if (left) {
            head->next = child;
            child->prev = head;
            left->next = next;
            if (next!=nullptr)
              next->prev = left;
        }
        
        if (head->next == nullptr)
            return head;
        return Rec(head->next);
    }
    Node* flatten(Node* head) {
        Rec(head);
        return head;
   }
}