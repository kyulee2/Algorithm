/*
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

Example 1:

Input: [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
             Total amount you can rob = 1 + 3 = 4.
Example 2:

Input: [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
             Total amount you can rob = 2 + 9 + 1 = 12.
*/
// Comment: Straightfowrd, but it's good basic of DP for refresh.
public class Solution {
    public int Rob(int[] nums) {
        // p[n] = max(p[n-1], p[n-2] + value(n))
        int len = nums.Length;
        var p = new int[len];
        if (len==0) return 0;
        if (len==1) return nums[0];
        if (len==2) return Math.Max(nums[0], nums[1]);
        p[0] = nums[0];
        p[1] = Math.Max(nums[0], nums[1]);
        
        // main loop
        for(int i=2; i<len; i++) {
            p[i] = Math.Max(p[i-1], p[i-2] + nums[i]);
        }
        return p[len-1];
    }
}

