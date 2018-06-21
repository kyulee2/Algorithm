/*
Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order, too.

You need to find the shortest such subarray and output its length.

Example 1:
Input: [2, 6, 4, 8, 10, 9, 15]
Output: 5
Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.
Note:
Then length of the input array is in range [1, 10,000].
The input array may contain duplicates, so ascending order here means <=.
*/
// Comment: A bit interesting. Find head/tail that decreases.
// Find min/max in the range of head/tail
// Keep increasing range until left <= min && right >= max
// One spoiler is the case where array is already sorted.
public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int len = nums.Length;
        int i=0, j=len-1;
        int left = -1, right =-1;
        // head
        for( i=1; i<len; i++)
            if (nums[i-1] > nums[i])
                break;
        // Spoiler: early out for already sorted one
        if (i==len) return 0;
        left = i==0? Int32.MinValue :nums[i-1];
        // tail;
        for(j=len-2; j>=0; j--)
            if (nums[j]>nums[j+1])
                break;
        right =j==len-1? Int32.MaxValue : nums[j+1];
        // min max
        int min = nums[i];
        int max = nums[i];
        for(int k=i+1; k<=j;k++) {
            min = Math.Min(min, nums[k]);
            max = Math.Max(max, nums[k]);
        }
        // increase range if needed
        while(left > min || right < max) {
            if (left > min) {
                if (i>0) {
                    --i;
                    left = i == 0? Int32.MinValue : nums[i-1];
                    min = Math.Min(min, nums[i]);
                    max = Math.Max(max, nums[i]);
                }
            }
            if (right < max) {
                if (j<len-1) {
                    ++j;
                    right = j==len-1 ? Int32.MaxValue : nums[j+1];
                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);
                }
            }
        }
        
        return j-i+1;
    }
}

