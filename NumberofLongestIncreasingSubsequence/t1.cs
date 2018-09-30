/*
Given an unsorted array of integers, find the number of longest increasing subsequence. 
Example 1:
Input: [1,3,5,4,7]
Output: 2
Explanation: The two longest increasing subsequence are [1, 3, 4, 7] and [1, 3, 5, 7].

Example 2:
Input: [2,2,2,2,2]
Output: 5
Explanation: The length of longest continuous increasing subsequence is 1, and there are 5 subsequences' length is 1, so output 5.

Note: Length of the given array will be not exceed 2000 and the answer is guaranteed to be fit in 32-bit signed int. 
*/
// Comment: Should watch. It's similar to LongestIncreasingSubsequence. It's just one more context
// which is counting such longest subsequence.
// Use two dp arrays. O(n^2) time and space.
public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        int len = nums.Length;
        if (len<=1) return len;
        
        // use two dp one for length and the other for count
        var length = new int[len]; // LIS at i'th index
        var count = new int[len];
        int maxLen = 1, maxCount = 1;
        length[0] = 1; count[0] = 1; // spoiler: init this
        for(int i=1; i<len; i++) {
            length[i] = 1;
            count[i] = 1;
            for(int j=0; j<i; j++) {
                if (nums[i]>nums[j]) {
                    if (length[i] == length[j] + 1)
                        count[i] += count[j];
                    else if (length[i] < length[j]+1) {
                        count[i] = count[j];
                        length[i] = length[j] + 1;
                    }
                }
            }

            // update max
            if (maxLen == length[i]) {
                maxCount += count[i];
            } else if (maxLen < length[i]) {
                maxCount = count[i];
                maxLen = length[i];
            }
        }
        
        return maxCount;
    }
}