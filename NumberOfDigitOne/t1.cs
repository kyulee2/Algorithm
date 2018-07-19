/*
Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.
Example:
Input: 13
Output: 6 
Explanation: Digit 1 occurred in the following num
*/
// Commnet: Think about order 2 and order 3 to formulate recursion.
// Split case between top digit is 1 or not.
public class Solution {
    public int CountDigitOne(int n) {
        if (n<=0) return 0;
        if (n<10) return 1;
        int m = 1;
        int d = n;
        while(d/10 > 0) {
            m *= 10;
            d /= 10;
        }
        
        int cnt = 0; // Count 1 at the highest order
        if (d==1) {
            cnt += n - d * m + 1;
            return cnt + CountDigitOne(n-d *m) + CountDigitOne(m-1);
        } else {
            cnt += m;
            return cnt + CountDigitOne(n-d*m) + d* CountDigitOne(m-1);
        }
    }
}

