/*
Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers. Return the maximum product you can get.

For example, given n = 2, return 1 (2 = 1 + 1); given n = 10, return 36 (10 = 3 + 3 + 4).

Note: You may assume that n is not less than 2 and not larger than 58.
*/
// Comment: Interesting. Use a DP O(n^2). There is O(n) math solution, though.
// The max below for each iteration can be shortened as
// Max(j, d[j]) * Max(i-j, d[i-j])
public class Solution {
    public int IntegerBreak(int n) {
        int[] d= new int[n+1];
        d[1] = 1;
        d[2] = 1;
        for(int i=3; i<=n; i++) {
            int max = 1;
            for(int j=2; j<i; j++) {
                var t = (i-j) * d[j];
                max = Math.Max(max, t);
                t = j * d[i-j];
                max = Math.Max(max, t);
                t = j * (i-j);
                max = Math.Max(max, t);
            }
            d[i] = max;
        }
        return d[n];
    }
}
