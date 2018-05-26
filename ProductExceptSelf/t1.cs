/*
Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Example:

Input:  [1,2,3,4]
Output: [24,12,8,6]
Note: Please solve it without division and in O(n).

Follow up:
Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
*/

// Comment: The below uses constant space (output buffer) with O(n) time.
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int len = nums.Length;
        int[] ans = new int[len];
        int s = 1;
        for(int i=len-1; i>=1; --i) {
            s *= nums[i];
            ans[i] = s;
        } 
        s = 1;
        ans[0] = ans[1];
        for(int i=1; i<len;i++) {
            s *= nums[i-1];
            if (i==len-1)
                ans[i] = s;
            else
                ans[i] = s * ans[i+1];
        }
        return ans;
    }
}


