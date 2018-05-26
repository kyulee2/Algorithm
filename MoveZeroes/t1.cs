/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Example:

Input: [0,1,0,3,12]
Output: [1,3,12,0,0]
Note:

You must do this in-place without making a copy of the array.
Minimize the total number of operations.
*/
public class Solution {
    public void MoveZeroes(int[] nums) {
        int j=0;
        for(int i=0; i<nums.Length; i++) {
            if (nums[i]==0) continue;
            if (i!=j) nums[j] = nums[i];
            j++;
        }
        for(;j < nums.Length; j++)
            nums[j] = 0;
    }
}

