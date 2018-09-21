/*
Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal. 
Note:
Each of the array element will not exceed 100.
The array size will not exceed 200.

Example 1: 
Input: [1, 5, 11, 5]

Output: true

Explanation: The array can be partitioned as [1, 5, 5] and [11].

Example 2: 
Input: [1, 2, 3, 5]

Output: false

Explanation: The array cannot be partitioned into equal sum subsets.
*/
// Comment: DP. 0,1 knapsack problem. quite interesting.
// dp[i,j] -- with i nums, can make j sum?
// The goal is to find whether all nums can make sum/2?
public class Solution {
    public bool CanPartition(int[] nums) {
        // 0, 1 knapsack problem
        int s = 0;
        int len = nums.Length;
        foreach(var n in nums)
            s+=n;
        if (s%2!=0)
            return false;
        s /= 2; // searching nums pick to reach half sum.
        
        var dp = new bool[len+1, s +1]; // With i nums, can make j sum?
        dp[0,0] = true;
        for(int i=1; i<len+1; i++)
            dp[i,0] = true; // no pick would make 0 sum
        for(int j=1; j<s + 1; j++)
            dp[0,j] = false; // without no num, can't make positive sum
        
        for(int i=1; i<len+1; i++)
            for(int j=1; j<s+1; j++) {
                dp[i,j] = dp[i-1,j]; // We can make j sum wihout i'th num (using i-1 nums)
                if (nums[i-1]<=j)
                    dp[i,j] |= dp[i-1, j-nums[i-1]]; // or we can include current num assuming i-1 items doesn't include it
                
                //Console.WriteLine("{0} {1} {2}", i,j, dp[i,j]);
            }
        
        return dp[len, s];
    }
}