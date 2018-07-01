/*
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
(i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).
You are given a target value to search. If found in the array return true, otherwise return false.
Example 1:
Input: nums = [2,5,6,0,0,1,2], target = 0
Output: true
Example 2:
Input: nums = [2,5,6,0,0,1,2], target = 3
Output: false
Follow up:
This is a follow up problem to Search in Rotated Sorted Array, where nums may contain duplicates.
Would this affect the run-time complexity? How and why?
*/
// Comment: Recursion instead of loop. See no equal condition.
public class Solution {
    public bool Search(int[] nums, int target) {
        int len = nums.Length;
        bool Rec(int i, int j) {
            if (i>j)
                return false;
            int m= i+(j-i)/2;
            if (nums[m] == target)
                return true;
            if (nums[m]<nums[j]) {
                if (nums[m]<target && target<nums[j])
                    return Rec(m+1, j);
            } else {
                if (nums[i]<target && target<nums[m])
                    return Rec(i, m-1);
            }
            return Rec(i, m-1) || Rec(m+1, j);
        }
        return Rec(0, len-1);
    }
}
