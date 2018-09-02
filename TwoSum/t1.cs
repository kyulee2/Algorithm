/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].
 
*/
// Comment: Easy using a map. One gotcha about uniquness below.
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        
        // indexing
        for(int i=0; i<nums.Length;i++)
            map[nums[i]] = i;
        
        var ans = new int[2];
        for(int i=0; i<nums.Length; i++)
            if (map.ContainsKey(target -nums[i])) {
                int j =  map[target-nums[i]];
                // spoiler: check i and j are unique
                if (i != j) {
                  ans[0] = i;
                  ans[1] = map[target-nums[i]];
                  break;
                }
            }
        
        return ans;
    }
}
