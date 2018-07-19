/*
Given an integer array, find three numbers whose product is maximum and output the maximum product.
Example 1:
Input: [1,2,3]
Output: 6

Example 2:
Input: [1,2,3,4]
Output: 24

Note:
The length of the given array will be in range [3,104] and all elements are in the range [-1000, 1000].
Multiplication of any three numbers in the input won't exceed the range of 32-bit signed integer.
*/
// Comment: This is a math problem. Either 3 max or 2 min * max produces maximum value.
public class Solution {
    public int MaximumProduct(int[] nums) {
        // Get 3 max and 2 min
        int max1 = Int32.MinValue, max2 = Int32.MinValue, max3= Int32.MinValue;
        int min1 = Int32.MaxValue, min2 = Int32.MaxValue;
        foreach(var n in nums) {
            if (n>max1) {
                max3 = max2;
                max2 = max1;
                max1 = n;
            } else if (n>max2) {
                max3 = max2;
                max2 = n;
            } else if (n>max3) {
                max3 = n;
            }
            if (n<min1) {
                min2 = min1;
                min1 = n;
            } else if (n<min2)
                min2 = n;
        }
        return Math.Max(max1*max2*max3, min1*min2*max1);
    }
}
