/*
Write a program to find the n-th ugly number.
Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
Example:
Input: n = 10
Output: 12
Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
Note:  
1 is typically treated as an ugly number.
n does not exceed 1690.
*/
// Comment: Use min of previous value *2, 3, or 5 for each index.
// Appears simple below, but quite interesting.
// There could be duplication like 2*3 = 3*2 = 6. So, we could independently increase l1, l2 or l3
// once it's contributed to the current value
public class Solution {
    public int NthUglyNumber(int n) {
        if (n<=0) return 0;
        if (n==1)
            return 1;
        int l1 = 1, l2 =1, l3 = 1;
        var ans = new int[n+1];
        ans[1] = 1;
        for(int i=2; i <=n; i++) {
            int t1 = ans[l1]*2;
            int t2 = ans[l2]*3;
            int t3 = ans[l3]*5;
            ans[i] = Math.Min(t1, Math.Min(t2, t3));
            if (ans[i] == t1)
                l1++;
            if (ans[i] == t2)
                l2++;
            if (ans[i] == t3)
                l3++;
        }
        return ans[n];
    }
}
