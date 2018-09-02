/*
Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.
Example 1:
Input: [1,3,4,2,2]
Output: 2
Example 2:
Input: [3,1,3,4,2]
Output: 3
Note:
You must not modify the array (assume the array is read only).
You must use only constant, O(1) extra space.
Your runtime complexity should be less than O(n2).
There is only one duplicate number in the array, but it could be repeated more than once.
*/
// Comment: Use sign to detect duplication.
// The first one modifies array. See the second solution using a bit count O(32n)
public class Solution {
    public int FindDuplicate(int[] nums) {
        for(int i=0; i<nums.Length; i++) {
            int nextI = Math.Abs(nums[i]) - 1;
            if (nums[nextI]>0)
                nums[nextI] = -nums[nextI];
            else
                return nextI+1;
        }
        
        return -1;
    }
}
// Comment: Use each bit count to detect more count which is duplicated
public class Solution {
    public int FindDuplicate(int[] nums) {
        int len = nums.Length; // n+1
        int ans = 0;
        for(int i=0; i<32; i++) {
            int bit = 1 << i;
            int a = 0, b = 0;
            for(int j=0; j<len; j++) {
                if (j>0) { // 1 ~ n
                    if ((j&bit) > 0)
                        a++;
                }
                if ((nums[j] & bit) > 0)
                    b++;
            }
            if (b>a)
                ans += bit;
        }
        return ans;
    }
}
