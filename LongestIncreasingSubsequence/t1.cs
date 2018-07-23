/*
Given an unsorted array of integers, find the length of longest increasing subsequence.

Example:

Input: [10,9,2,5,3,7,101,18]
Output: 4 
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 
Note:

There may be more than one LIS combination, it is only necessary for you to return the length.
Your algorithm should run in O(n2) complexity.
Follow up: Could you improve it to O(n log n) time complexity?
*/
// Comment: Use DP below. We could do this using binary search by building up d.
public class Solution {
    public int LengthOfLIS(int[] nums) {
        // DP O(n^2)
        int len = nums.Length;
        if (len==0) return 0;
        var d = new int[len];
        for(int i=0; i<len; i++)
            d[i] = 1;
        int max = 1;
        for(int i=1; i<len; i++) {
            for(int j=0; j<i; j++)
                if (nums[i]>nums[j])
                    d[i] = Math.Max(d[i], d[j]+1);
            max = Math.Max(max, d[i]);
        }
        return max;
    }
}
