/*
In the computer world, use restricted resource you have to generate maximum benefit is what we always want to pursue.

For now, suppose you are a dominator of m 0s and n 1s respectively. On the other hand, there is an array with strings consisting of only 0s and 1s.

Now your task is to find the maximum number of strings that you can form with given m 0s and n 1s. Each 0 and 1 can be used at most once.

Note:
The given numbers of 0s and 1s will both not exceed 100
The size of given string array won't exceed 600.
Example 1:
Input: Array = {"10", "0001", "111001", "1", "0"}, m = 5, n = 3
Output: 4

Explanation: This are totally 4 strings can be formed by the using of 5 0s and 3 1s, which are “10,”0001”,”1”,”0”
Example 2:
Input: Array = {"10", "0", "1"}, m = 1, n = 1
Output: 2

Explanation: You could form "10", but then you'd have nothing left. Better form "0" and "1".

*/
// Comment: Use Rec + caches below. It should be doable with DP.
// Using Tuple is readable but time-out 58/63.
// As commented code, using 3-dim array cache simply passed.
public class Solution {
    
    //Dictionary<Tuple<int, int, int>, int> cache; // m, n, row/i to cnt
    int[,,] cache;
    Dictionary<string, int[]> map;
    int len;
    int Rec(int i, int m, int n) {
        if (i==len) {
            return 0;
        }
        /*
        Tuple<int, int, int> t = new Tuple<int, int, int>(m,n,i);
        if (cache.ContainsKey(t)) {
            return cache[t];
        }
        */
        if (cache[m,n,i] != -1) 
            return cache[m,n,i];
        
        int ans = 0;
        var v = map[s[i]];
        if (v[0] >m || v[1]>n) {
            ans = Rec(i+1, m, n);
        } else {
            ans = Math.Max(Rec(i+1, m-v[0], n-v[1]) + 1,
                Rec(i+1, m,n));
        }
        //cache[t] = ans;
        cache[m,n,i] = ans;
        return ans;
    }
    string[] s;
    public int FindMaxForm(string[] strs, int m, int n) {
        // Init data
        s = strs;
        len = strs.Length;
        map = new Dictionary<string, int[]>(); // str to m/n
        //cache = new Dictionary<Tuple<int, int, int>, int>();
        cache = new int[m+1, n+1, len];
        for(int i=0; i<m+1; i++)
            for(int j=0; j<n+1; j++)
                for(int k=0; k<len; k++)
                    cache[i,j,k] = -1;
        
        foreach(var s in strs) {
            int m1 =0; int n1 = 0;
            foreach(var c in s)
                if (c == '0')
                    m1++;
                else n1++;
            map[s] = new int[]{m1, n1};
        }
        return Rec(0, m, n);
    }
}

