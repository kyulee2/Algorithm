/*
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
Example:

Input: [1,2,3,0,2]
Output: 3 
Explanation: transactions = [buy, sell, cooldown, buy, sell]
*/
// Comment: Quite interesting. Use state machines, buy/sell/rest.
// Careful about initial condition.
public class Solution {
    public int MaxProfit(int[] prices) {
        int len = prices.Length;
        if (len<=1) return 0;
        
        var buy = new int[len];
        var sell = new int[len];
        var rest = new int[len];
        buy[0] = -prices[0];
        sell[0] = int.MinValue;        
        rest[0] = 0;
        
        for(int i=1; i<len; i++) {            
            rest[i] = Math.Max(rest[i-1], sell[i-1]);
            buy[i] = Math.Max(buy[i-1], rest[i-1] - prices[i]);
            sell[i] = buy[i-1] + prices[i];
        }
        
        return Math.Max(sell[len-1], rest[len-1]);
    }
}
