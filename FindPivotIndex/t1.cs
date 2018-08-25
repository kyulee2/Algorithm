/*
Given an array of integers nums, write a method that returns the "pivot" index of this array.

We define the pivot index as the index where the sum of the numbers to the left of the index is equal to the sum of the numbers to the right of the index.

If no such index exists, we should return -1. If there are multiple pivot indexes, you should return the left-most pivot index.

Example 1:
Input: 
nums = [1, 7, 3, 6, 5, 6]
Output: 3
Explanation: 
The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the sum of numbers to the right of index 3.
Also, 3 is the first index where this occurs.
Example 2:
Input: 
nums = [1, 2, 3]
Output: -1
Explanation: 
There is no index that satisfies the conditions in the problem statement.
Note:

The length of nums will be in the range [0, 10000].
Each element nums[i] will be an integer in the range [-1000, 1000].
*/
// Comment: Easy and striaghtfoward
public class Solution {
    public int PivotIndex(int[] nums) {
        int len = nums.Length;
        if (len==0) return -1;
        if (len==1) return 0;
        int[] sum = new int[len];
        int s= 0;
        for(int j=len-1; j>=0; j--) {
            s += nums[j];
            sum[j] = s;
        }
        
        s = nums[0];
        if (sum[1]==0) return 0;
        for(int i=1; i<len-1; i++) {
            if (s == sum[i+1]) return i;
            s += nums[i];
        }
        if (s==0) return len-1;
        return -1;
    }
}
