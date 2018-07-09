/*
Given a binary array, find the maximum number of consecutive 1s in this array.
Example 1:
Input: [1,1,0,1,1,1]
Output: 3
Explanation: The first two digits or the last three digits are consecutive 1s.
    The maximum number of consecutive 1s is 3.

Note: 
The input array will only contain 0 and 1.
The length of input array is a positive integer and will not exceed 10,000
*/
// Comment: Easy. Not worth
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int max = 0;
        int curr = 0;
        for(int i=0; i<nums.Length; i++) {
            if (nums[i] == 1) {
                curr++;
                max = Math.Max(max, curr);
            } else {
                curr = 0;
            }
        }
        return max;
    }
}
