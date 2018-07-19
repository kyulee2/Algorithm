/*
You are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin.
Note: You can assume that
0 <= amount <= 5000
1 <= coin <= 5000
the number of coins is less than 500
the answer is guaranteed to fit into signed 32-bit integer
 
Example 1:
Input: amount = 5, coins = [1, 2, 5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
 
Example 2:
Input: amount = 3, coins = [2]
Output: 0
Explanation: the amount of 3 cannot be made up just with coins of 2.
 
Example 3:
Input: amount = 10, coins = [10] 
Output: 1
*/
// Comment: Traditional rec + mem. Using array limits memory.
// Note 0 amount is 1 way, not 0 way.
// Sort coins and force start index to narrow scope
public class Solution {
    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        Array.Reverse(coins);
        var map = new Dictionary<Tuple<int, int>, int>();
        
        int Rec(int n, int start)
        {
            if (n==0)
                return 1;
            var key = new Tuple<int, int>(n, start);
            if (map.ContainsKey(key))
                return map[key];
                
            int ans = 0;
            for(int i=start; i < coins.Length; i++) {
                int c = coins[i];
                if (n >=c)
                    ans +=Rec(n-c, i);
            }
            
            map[key] = ans;
            return ans;
        }
        

        return Rec(amount, 0);
    }
}
