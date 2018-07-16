/*
Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
Example 1:
Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.
Example 2:
Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
*/
// Comment: Rec + memoization
public class Solution {
    public int NumSquares(int n) {
        var map = new Dictionary<int, int>(); // num to cnt
        map[1] = 1;
        map[0]= 0;
        int Rec(int m, int cnt)
        {
            if (map.ContainsKey(m))
                return map[m] + cnt;
            int max = (int)Math.Sqrt(m);
            int t = Int32.MaxValue;
            for(int i=1; i<=max; i++) {
                t = Math.Min(t, Rec(m-i*i, 1));
            }
            map[m] = t;
            return t+cnt;
        }
        
        return Rec(n, 0);
    }
}
