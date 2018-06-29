/*
Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum >= s. If there isn't one, return 0 instead.

Example: 

Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.
Follow up:
If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n). 
*/

// Comment: Quite interesting. Use two pointers in O(n) solution.
// This works since all elements are positive.
public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int len = nums.Length;
        if (len == 0)
            return 0;
        int sum = 0, j=0;
        int min = Int32.MaxValue;
        for(int i=0; i<len; i++) {
            sum += nums[i];
            while(s<=sum) {
                min = Math.Min(min, i-j+1);
                sum -= nums[j++];
            }
        }
        return min==Int32.MaxValue ? 0 : min;
    }
}
