/*
Given two integers dividend and divisor, divide two integers without using multiplication, division and mod operator.
Return the quotient after dividing dividend by divisor.
The integer division should truncate toward zero.
Example 1:
Input: dividend = 10, divisor = 3
Output: 3
Example 2:
Input: dividend = 7, divisor = -3
Output: -2
Note:
Both dividend and divisor will be 32-bit signed integers.
The divisor will never be 0.
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [-231,  231 - 1]. For the purpose of this problem, assume that your function returns 231 - 1 when the division result overflows.
*/
// Comment: D = S * P (where P is 2^n)
// The below (with/without comment) works in both ways. Use long instead of int to hand Int32.MinValue which will overflow with Math.Abs
public class Solution {
    public int Divide(int dividend, int divisor) {        
        long dvd = dividend;
        long dvs = divisor;
        
        // spoiler: 
        //if (dvs ==0 || (dvd == Int32.MinValue && dvs==-1))
        //    return Int32.MaxValue;

        dvd = Math.Abs(dvd);
        dvs = Math.Abs(dvs);
        
        bool sign = (dividend == dvd) ^ (divisor == dvs);
        long ans = 0;
        // DVD = DVS * P (where p = 2^n)
        while(dvd >= dvs) {
            long p = 1;
            long s = dvs;
            while(dvd >= (s<<1)) {
                s <<= 1;
                p <<= 1;
            }
            dvd -= s;
            ans += p;
        }

        //return sign ? -ans : ans;
        if (sign) ans = -ans;
        return ans>Int32.MaxValue ? Int32.MaxValue : (ans < Int32.MinValue ? Int32.MinValue : (int)ans);
    }
}