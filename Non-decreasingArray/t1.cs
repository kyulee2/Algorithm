/*
Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.

We define an array is non-decreasing if array[i] <= array[i + 1] holds for every i (1 <= i < n).

Example 1:
Input: [4,2,3]
Output: True
Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
Example 2:
Input: [4,2,1]
Output: False
Explanation: You can't get a non-decreasing array by modify at most one element.
Note: The n belongs to [1, 10,000].
*/
// Comment: The key idea is to find the down hill, say start.
// Consider 4 elements: start-1, start, start+1, start+2
// We can either push down start, or raise start+1 up
public class Solution {
    public bool CheckPossibility(int[] nums) {
        int len = nums.Length;
        // check count of decreasing
        int cnt=0;
        int start = -1;
        for(int i=1; i<len; i++) {
            if (nums[i-1] > nums[i]) {
                if (start == -1)
                    start = i - 1;
                cnt++;
            }
        }
        if (cnt==0) return true;
        if (cnt>=2) return false;
        if (start == 0 || start+1==len-1) return true;
        // either start down to next or start+1 to next's next
        return nums[start-1] <= nums[start+1] || nums[start]<= nums[start+2];
    }
}

