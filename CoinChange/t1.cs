/*
You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

Example 1:

Input: coins = [1, 2, 5], amount = 11
Output: 3 
Explanation: 11 = 5 + 5 + 1
Example 2:

Input: coins = [2], amount = 3
Output: -1
Note:
You may assume that you have an infinite number of each kind of coin.
*/
// Comment: Good practice for recusrion + memoization. Careful about checking recursion return value before applying min operation below.
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        Array.Sort(coins);
        Array.Reverse(coins); 
        var map = new Dictionary<int, int>();
        int Rec(int n)
        {
            if (n<0) return -1;
            if (n==0) return 0;
            // cache
            if (map.ContainsKey(n))
                return map[n];
            
            int min = Int32.MaxValue;
            for(int i=0; i<coins.Length; i++) {
                if (coins[i]<=n) {
                    // Spoiler: check ret first;
                    int ret = Rec(n-coins[i]);
                    if (ret != -1)
                        min = Math.Min(ret + 1, min);
                }
            }
            if (min == Int32.MaxValue)
                min = -1;

            map[n] = min;
            return min;
        }
        
        return Rec(amount);
    }
}
