/*

Given an integer array nums, find the sum of the elements between indices i and j (i = j), inclusive.

Example:
Given nums = [-2, 0, 3, -5, 2, -1]

sumRange(0, 2) -> 1
sumRange(2, 5) -> -1
sumRange(0, 5) -> -3
Note:
You may assume that the array does not change.
There are many calls to sumRange function.
*/
// Comment: Easy. Not worth.
public class NumArray {

    int[] sums;
    int len;
    public NumArray(int[] nums) {
        len = nums.Length;
        sums = new int[len];
        int sum = 0;
        for(int i=0; i<len; i++) {
            sum += nums[i];
            sums[i] = sum;
        }
    }
    
    public int SumRange(int i, int j) {
        if (i==0)
            return sums[j];
        return sums[j] - sums[i-1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
