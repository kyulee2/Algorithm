/*
Given an integer, write a function to determine if it is a power of two.
Example 1:
Input: 1
Output: true
Example 2:
Input: 16
Output: true
Example 3:
Input: 218
Output: false
*/
// Comment: Bail out 0 and negative value early
public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n<=0) return false;
        return (n & (n-1)) == 0;
    }
}
