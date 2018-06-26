/*
Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.

Example:

Input:  [1,2,1,3,2,5]
Output: [3,5]
Note:

The order of the result is not important. So in the above example, [5, 3] is also correct.
Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?
*/
// Comment: Split two groups based on anybit of xor result is important.
public class Solution {
    public int[] SingleNumber(int[] nums) {
        int xor = 0;
        foreach(var v in nums)
            xor ^= v;
        // get the last bit set
        xor &= -xor;
        
        int left = 0, right = 0;
        foreach(var v in nums) {
            if ((xor & v) == 0)
                left ^= v;
            else
                right ^= v;
        }
        return new int[] {left, right};
    }
}


