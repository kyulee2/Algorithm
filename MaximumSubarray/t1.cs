/*
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
Example:
Input: [-2,1,-3,4,-1,2,1,-5,4],
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
Follow up:
If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
*/
// Comment: Init with first entry. For negative curr, reset curr, or accumulate curr, and update max out of it
public class Solution {
    public int MaxSubArray(int[] nums) {
        int max = nums[0];
        int curr = nums[0];
        for(int i=1; i<nums.Length; i++) {
            int n = nums[i];
            if (curr<0)
                curr = Math.Max(curr, n);
            else
                curr += n;
            max = Math.Max(curr, max);
        }
        return max;
    }
}
