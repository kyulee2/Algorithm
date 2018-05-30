/*
On a staircase, the i-th step has some non-negative cost cost[i] assigned (0 indexed). 
Once you pay the cost, you can either climb one or two steps. You need to find minimum cost to reach the top of the floor, and you can either start from the step with index 0, or the step with index 1. 
Example 1:
Input: cost = [10, 15, 20]
Output: 15
Explanation: Cheapest is start on cost[1], pay that cost and go to the top.

Example 2:
Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
Output: 6
Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3].

Note:
cost will have a length in the range [2, 1000].
Every cost[i] will be an integer in the range [0, 999].
*/

// Comment: There are three ways. The first two causes time-out failure.
// 1. Naive Recursion that adds cost by visiting i+1 or i+2, and set min at the end
// 2. Similar to 1, but saves recursion history per index, and do the rest only when current added cost is smaller
// 3. The below solution. Think it backward. Set min[i] is the cost to climb to the top.
//    Spoiler: The answer is Min(min[0], min[1])  not min[0]

public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int len = cost.Length;
        if (len == 1)
            return cost[0];
        if (len == 2)
            return Math.Min(cost[0], cost[1]);
        int[] min = new int[len];
        
        min[len-1] = cost[len-1];
        min[len-2] = cost[len-2];
        for(int i=len-3; i>=0; i--) {
            min[i] = cost[i] + Math.Min(min[i+1], min[i+2]);
        }
        
        return Math.Min(min[0], min[1]);
    }
}

