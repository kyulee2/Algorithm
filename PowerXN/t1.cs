/*
Implement pow(x, n), which calculates x raised to the power n (xn).
Example 1:
Input: 2.00000, 10
Output: 1024.00000
Example 2:
Input: 2.10000, 3
Output: 9.26100
Example 3:
Input: 2.00000, -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
Note:
-100.0 < x < 100.0
n is a 32-bit signed integer, within the range [-231, 231 - 1]
*/
// Comment: Appears simple, but important
public class Solution {
    public double MyPow(double x, int n) {
        bool isNeg = false;
        long m = n; // spoiler: overflow
        if (n<0)  {
            isNeg = true;
            m = -m;
        }
        double b = x;
        double ans = 1;
        while(m>0) {
            if (m%2!=0) {// odd
                ans *= b;
            }
            m >>=1;
            b *= b;
        }
        
        return isNeg ? 1/ ans : ans;
    }
}

