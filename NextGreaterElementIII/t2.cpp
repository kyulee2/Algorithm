/*
Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.

Example 1:

Input: 12
Output: 21
 

Example 2:

Input: 21
Output: -1
*/
// Comment: It's finding next permutation order.
// backward/forward search followed by reverse.
// Try with examples to see how they work.
// O(n) time and O(1) space where n is # of digits.
// One spoiler about checking validity of int32.
class Solution {
public:
    int nextGreaterElement(int n) {
        auto S = to_string(n);
        int len = S.length();
        // Find the last increasing pair (backward)
        int i = 0;
        for(i=len-2; i>=0; i--)
            if (S[i] < S[i+1]) break;
        
        if (i<0) return -1;
        
        int j= i +1;
        // Find the last S[j] that still is > S[i] (forward)
        while(j<len && S[i]<S[j])
            j++;
        j--;
        
        // Swap
        auto temp  = S[i];
        S[i]  = S[j];
        S[j] = temp;
        
        // Reverse i+1 ~ len-1
        i++; j= len-1;
        while(i<j) {
            temp = S[i];
            S[i] = S[j];
            S[j] = temp;
            i++; j--;
        }
        
        int ans;
        try {
            ans = stoi(S);
        }
        catch(...) {
            return -1;
        }
        return ans;
    }
};
