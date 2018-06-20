/*
In a given integer array nums, there is always exactly one largest element.
Find whether the largest element in the array is at least twice as much as every other number in the array.
If it is, return the index of the largest element, otherwise return -1.
Example 1:
Input: nums = [3, 6, 1, 0]
Output: 1
Explanation: 6 is the largest integer, and for every other number in the array x,
6 is more than twice as big as x.  The index of value 6 is 1, so we return 1.
 
Example 2:
Input: nums = [1, 2, 3, 4]
Output: -1
Explanation: 4 isn't at least as big as twice the value of 3, so we return -1.
 
Note:
nums will have a length in the range [1, 50].
Every nums[i] will be an integer in the range [0, 99].
*/
// Comment: Easy. Just maintain max and maxnext. One spoiler is to handle single element which should be treated as valid.
public class Solution {
    public int DominantIndex(int[] nums) {
        int len = nums.Length;
        if (len==1) return 0; // spoiler: one element is treated as valid
        if (len==2) {
            if (nums[0]> nums[1] && nums[0] >= nums[1] * 2) return 0;
            if (nums[0]< nums[1] && nums[0] <= nums[1] * 2) return 1;
            return -1;
        }
        int max = 0, maxid = 0, maxnext = 0;
        if (nums[0]>nums[1]) {
            max = nums[0];
            maxid = 0;
            maxnext = nums[1];
        } else {
            max = nums[1];
            maxid = 1;
            maxnext = nums[0];
        }
        
        // Main loop
        for(int i = 2; i<len; i++) {
            // check maxnext
            int n = nums[i];
            if (n < maxnext)
                continue;
            if (n>= maxnext && n<max) {
                maxnext = n;
                continue;
            }
            
            maxnext = max;
            max = n;
            maxid = i;            
        }
        
        if (max >= maxnext * 2)
            return maxid;
        return -1;
    }
}


