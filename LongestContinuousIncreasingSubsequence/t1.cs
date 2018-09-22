/*
Given an unsorted array of integers, find the length of longest continuous increasing subsequence (subarray). 
Example 1:
Input: [1,3,5,4,7]
Output: 3
Explanation: The longest continuous increasing subsequence is [1,3,5], its length is 3. 
Even though [1,3,5,7] is also an increasing subsequence, it's not a continuous one where 5 and 7 are separated by 4. 

Example 2:
Input: [2,2,2,2,2]
Output: 1
Explanation: The longest continuous increasing subsequence is [2], its length is 1. 

Note: Length of the array will not exceed 10,000. 
*/
// COmment: Easy. Just reset curr = 1 when not increase.
public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        if (nums.Length==0)
            return 0;
        int ans = 1;
        int curr = 1;
        for(int i=1; i<nums.Length; i++)
            if (nums[i]>nums[i-1]) {
                curr++;
                ans = Math.Max(ans, curr);
            }
            else curr = 1;
        
        return ans;
    }
}