/*
Given an unsorted integer array, find the smallest missing positive integer.
Example 1:
Input: [1,2,0]
Output: 3
Example 2:
Input: [3,4,-1,1]
Output: 2
Example 3:
Input: [7,8,9,11,12]
Output: 1
Note:
Your algorithm should run in O(n) time and uses constant extra space.
*/
// Comment: A bit tricky. When not fodund, returning the len + 1 below.
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int len = nums.Length;
        // To align a[j] = j starting from 1
        for(int i=0; i<len; i++)
            --nums[i];
        
        // Enforce a[i] = i
        for(int i=0; i<len; i++) {
            if (nums[i] != i) {
                int j= nums[i];
                while(j>=0 && j<len && nums[j] != j) {
                    int t = nums[j];
                    nums[j] = j;
                    j = t;
                }
            }
        }
        
        // Find ans
        for(int i=0; i<len; i++)
            if (nums[i] != i)
                return i+1;
        
        return len+1;
    }
}
