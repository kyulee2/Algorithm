/*
Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.
Example 1:
Input: [5,7]
Output: 4
Example 2:
Input: [0,1]
Output: 0
*/
// Comment: This is quite interesting. Looks for the common prefix bits of m with n.
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
    int a = 0;
    while(m != n) {
        m >>= 1;
        n >>= 1;
        a++;
    }
    return m<<a; 
    }
}
