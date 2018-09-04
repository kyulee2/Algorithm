/*
Implement int sqrt(int x).
Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
Example 1:
Input: 4
Output: 2
Example 2:
Input: 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since 
             the decimal part is truncated, 2 is returned.
*/
// Comment: See condition to break out of the loop.
// The key point is to record ans with lowerbound.
public class Solution {
    public int MySqrt(int x) {
        if (x<=1)
            return x;
        long i =1, j=x-1;
        long ans = 1;
        while(i<=j) {
            long m = (i+j)/ 2;
            long t = m * m;
            if (t == x)
                return (int)m;
            else if (t > x) {
                j = m-1;
            } else {
                i = m+1;
                ans = m; // record potentil answer with the lower bound
            }
        }
        
        return (int)ans;
    }
}
