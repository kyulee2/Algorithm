/*
Given an array of numbers, verify whether it is the correct preorder traversal sequence of a binary search tree.
You may assume each number in the sequence is unique.
Consider the following binary search tree: 
     5
    / \
   2   6
  / \
 1   3
Example 1:
Input: [5,2,6,1,3]
Output: false
Example 2:
Input: [5,2,1,3,6]
Output: true
*/
// Comment: This should be similar to reconstruct BST from preorder sequence.
// The key idea is to identify the greater than the current root value and split array from there.
// Ensure passing not only range of array but also min/max value that will check the validity of the entries
class Solution {
public:
    bool verifyPreorder(vector<int>& preorder) {
        std::function<bool(int,int,int,int)> rec
             = [&rec, preorder](int i, int j, int min, int max)->bool {
            if (i>=j) return true;
            auto t = preorder[i];
            int k = i+1;
            for(    ; k<=j; k++) {
                int p = preorder[k];
                if (p<min|| p>max) return false;
                if (preorder[k] < t) continue;
                break;
            }
            return rec(i+1, k-1, min, t) && rec(k, j, t, max);
        };
        return rec(0, preorder.size()-1, INT_MIN, INT_MAX);
    }
};
