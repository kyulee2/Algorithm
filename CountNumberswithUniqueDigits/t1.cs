/*
Given a non-negative integer n, count all numbers with unique digits, x, where 0 <= x < 10^n.
Example:
Given n = 2, return 91. (The answer should be the total numbers in the range of 0 <= x < 100,
excluding [11,22,33,44,55,66,77,88,99])

*/
// Comment: A simple DP and math. Eg, unique 3 digits == 9 * 9 * 8 -- note the first digit shouldn't be zero.
// Adding up all digit cases.
public class Solution {
    public int CountNumbersWithUniqueDigits(int n) {
        if (n==0) return 1;
        if (n==1) return 10;
        var d = new int[n+1];
        d[1] = 10;
        for(int i=2; i<=n; i++) {
            int res = 9;
            int p = 9;
            for(int j=1; j<i; j++) {
                res *= p;
                p--;
            }
            d[i] = res + d[i-1];
        }
        
        return d[n];
    }
}
