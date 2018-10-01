/*
Given a 32-bit signed integer, reverse digits of an integer.
Example 1:
Input: 123
Output: 321
Example 2:
Input: -123
Output: -321
Example 3:
Input: 120
Output: 21
Note:
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [-231,  231 - 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
*/
// Comment: A bit tricky if we use int. Use long and check valid range or return 0
public class Solution {
    public int Reverse(int x) {
        long ans = 0;
        long X = x;
        bool isNegative = false;
        if (X<0) {
            isNegative = true;
            X = -X;
        }
        while(X>0) {
            long d = X % 10;
            X /= 10;
            ans *= 10;
            ans += d;
        }
        if (!isNegative  && ans>Int32.MaxValue)
            return 0;
        if (isNegative  && -ans<Int32.MinValue)
            return 0;
        return isNegative ? (int)(-ans) : (int)ans;
    }
}