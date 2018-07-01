/*
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.

Your algorithm's runtime complexity must be in the order of O(log n).

Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4
Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
*/
public class Solution {
    public int Search(int[] nums, int target) {
        int len = nums.Length;
        //int i=0, j=len-1;
        // left contiguous, right start
        // left < target< m, search left
        // or right
        //
        // right contiguous, left start
        // m < target < right, search right
        // or left
        int i =0, j=len-1;
        while(i<=j) {
            int m = i+ (j-i)/2;
            if (nums[m] == target)
                return m;
            if (nums[i]<=nums[m]) { // prior to left
                if (nums[i]<=target && target<=nums[m])
                    j = m-1;
                else
                    i= m+1;
            } else {
                if (nums[m]<=target && target<=nums[j])
                    i = m + 1;
                else
                    j = m - 1;
            }
        }
        
        return -1;
    }
// Another one still works, but not readable 
/*
    public int Search(int[] nums, int target) {
        int len = nums.Length;
        //int i=0, j=len-1;
        // left contiguous, right start
        // target< m, search left and right
        // target> m, search right
        // right contiguous, left start
        // target<m, search left
        // target> m, search left, right
        int Rec(int i, int j)
        {
            while(i<=j) {
                int m = i+ (j-i)/2;
                if (nums[m] == target)
                    return m;
                if (target<nums[m]) {
                    if (nums[j] > nums[m])
                        return Rec(i, m-1);
                } else {
                    if (nums[i] < nums[m])
                        return Rec(m+1, j);
                }
                int l = Rec(i,m-1);
                if (l!=-1) return l;
                return Rec(m+1, j);
            }
            return -1;
        }
        return Rec(0, len-1);
    }
*/
}

