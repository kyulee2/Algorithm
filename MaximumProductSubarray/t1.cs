/*
Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.
Example 1:
Input: [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
Example 2:
Input: [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray
*/
// Comment: O(n). Once hit the zero, reset product. The max product is from either side or before/after 0.
public class Solution {
    public int MaxProduct(int[] nums) {
        int len = nums.Length;
        int max = Int32.MinValue;
        int p = 1;
        // search forward
        for(int i=0; i<len; i++) {
            p *= nums[i];
            max = Math.Max(max, p);
            if (p==0) p = 1; // reset p
        }
        
        // search backward
        p = 1;
        for(int i=len-1; i>=0; i--) {
            p*= nums[i];
            max = Math.Max(max, p);
            if (p==0) p = 1; //reset p
        }
        return max;
    }
}
