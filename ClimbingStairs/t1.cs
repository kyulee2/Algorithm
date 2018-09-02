/*
You are climbing a stair case. It takes n steps to reach to the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
Note: Given n will be a positive integer.
Example 1:
Input: 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
Example 2:
Input: 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
*/
// Comment : Easy Dp
public class Solution {
    public int ClimbStairs(int n) {
        // d[n] = d[n-1] + d[n-2]
        if (n<1) return 0;
        if (n<=2) return n;
        var d = new int[n+1];
        d[1] = 1;
        d[2] = 2;
        for(int i=3; i<=n; i++)
            d[i] = d[i-1]+d[i-2];
        return d[n];
    }
}
