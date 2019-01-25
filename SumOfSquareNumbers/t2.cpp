/*
Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.

Example 1:
Input: 5
Output: True
Explanation: 1 * 1 + 2 * 2 = 5
Example 2:
Input: 3
Output: False
*/
// Comment: Various ways. Either use two pointers or binary search.
// The blow uses two pointers. O(sqrt c).
// Space is O(1)
class Solution {
public:
    bool judgeSquareSum(int c) {
        if (c<0) return false;
        if (c<=2) return true;
        int i =0, j=(int) sqrt(c);
        while(i<=j) {
            int s =i*i + j*j;
            if (s == c) return true;
            if (s<c)
                i++;
            else j--;
        }
        return false;
    }
};
