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
public class Solution {
    public bool VerifyPreorder(int[] preorder) {
        bool Rec(int i, int j, int min, int max)
        {
            if (i>=j) return true;
            var t = preorder[i];
            int k = i+1;
            int p =-1;
            for(; k<=j; k++) {
                p = preorder[k];
                if (p<min || p>max) return false;
                if (preorder[k]<t) continue;
                break;
            }
            return Rec(i+1,k-1, min, t) && Rec(k, j, t, max);
        }
        return Rec(0, preorder.Length-1, Int32.MinValue, Int32.MaxValue);
    }
}