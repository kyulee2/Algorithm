/*
Given a positive integer n and you can do operations as follow: 

If n is even, replace n with n/2.
If n is odd, you can replace n with either n + 1 or n - 1.

What is the minimum number of replacements needed for n to become 1? 

Example 1: 
Input:
8

Output:
3

Explanation:
8 -> 4 -> 2 -> 1

Example 2: 
Input:
7

Output:
4

Explanation:
7 -> 8 -> 4 -> 2 -> 1
or
7 -> 6 -> 3 -> 2 -> 1
*/
// Comment: Two time-out cases. 
// 1. Naive DP. Don't need to iterate one by one. Failed with 100000
// 2. Recursion with cache. Failed due to memory with 2147483647
// Last one works. Key observaction is to see the last 3 bits.
// 1,3,5 odd cases, it's better to decrement value. Otherwise,
// Adding one to create 2^n bit (n>=3)
public class Solution {
    /*
    public int IntegerReplacement(int n) {
        if (n==1) return 0;
        if (n==2) return 1;
        if (n==3) return 2;
        int[] p = new int[n+2];
        p[2] = 1;
        for(int i=4; i<=n+1; i+=2) {
            p[i] = p[i/2] + 1;
            p[i-1] = Math.Min(p[i], p[i-2]) + 1;
        }
        return p[n];
    }
    */
    /*
    Dictionary<int, int> p;
    int Rec(int n) {
        if (n==1) return 0;
        
        if (p.ContainsKey(n)) return p[n];
        if (n==2) return 1;
        int ans = 0;
        if (n%2 == 0) {
            ans = Rec(n/2) + 1;
        } else {
            ans = Math.Min(Rec(n+1), Rec(n-1)) + 1;
        }
        
        p[n] = ans;
        return ans;
    }
    public int IntegerReplacement(int n) {        
        if (n==1) return 0;
        if (n==2) return 1;
        p = new Dictionary<int, int>();
        p[2] = 1;
        return Rec(n);
    }
    */
    public int IntegerReplacement(int num) {
        long n = (long)num;
        if (n==1) return 0;
        int cnt = 0;
        while(n  != 1) {
            if (n%2 == 0) {
                n >>= 1;
            } else {
                long a = n & 7;
                if (a < 7)
                    --n;
                else
                    ++n;                
            }
            cnt++;
        }
        return cnt;
    }
}
