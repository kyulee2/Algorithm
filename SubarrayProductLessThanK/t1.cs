/*
Your are given an array of positive integers nums.

Count and print the number of (contiguous) subarrays where the product of all the elements in the subarray is less than k.

Example 1:
Input: nums = [10, 5, 2, 6], k = 100
Output: 8
Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.
Note:

0 < nums.length <= 50000.
0 < nums[i] < 1000.
0 <= k < 10^6.
*/
// Comment: Interesting with two pointers.
// Easy to stumble the case. 

public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {

        int len = nums.Length;
        int p = 1;
        int ans =  0;
        for(int i=0, j=0; j < len; j++) {
            p *= nums[j];
            while(i<=j && p>=k) {
                p /= nums[i++];
            }
            ans += j- i + 1;
        }
        return ans;
    }
}