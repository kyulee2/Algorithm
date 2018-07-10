/*
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
Example 1:
Input: [2,3,2]
Output: 3
Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2),
             because they are adjacent houses.
Example 2:
Input: [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
             Total amount you can rob = 1 + 3 = 4
*/
// Comment: Think two ranges: 0 ~ n-2, 1 ~ n-1.
public class Solution {
    public int Rob(int[] nums) {
        int len = nums.Length;
        if (len==0) return 0;
        if (len==1) return nums[0];
        if (len==2) return Math.Max(nums[0], nums[1]);
        if (len==3) return Math.Max(nums[0], Math.Max(nums[1], nums[2]));
        var p = new int[len];
        var q = new int[len];
        var r = new int[len];
        
        p[0] = nums[0];
        p[1] = Math.Max(nums[0], nums[1]);
        q[1] = nums[1];
        q[2] = Math.Max(nums[1], nums[2]);
        
        for(int i=2; i<len-1; i++)
            p[i] = Math.Max(p[i-1], p[i-2]+nums[i]);
        for(int i=3; i<len; i++)
            q[i] = Math.Max(q[i-1], q[i-2]+nums[i]);
        for(int i=2; i<len; i++)
            r[i] = Math.Max(p[i-1], q[i]);
        
        return r[len-1];
    }
}

