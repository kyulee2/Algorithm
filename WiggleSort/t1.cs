/*
Given an unsorted array nums, reorder it in-place such that nums[0] <= nums[1] >= nums[2] <= nums[3]....
Example:
Input: nums = [3,5,2,1,6,4]
Output: One possible answer is [3,5,1,6,2,4]
*/
public class Solution {
    public void WiggleSort(int[] nums) {
        for(int i=0; i<nums.Length - 1; i++) {
            int curr = nums[i];
            int next = nums[i+1];
            if (i%2 == 0) { // <
                if (curr <= next) continue;
            }
            else { // >
                if (curr >= next) continue;
            }
            nums[i] = next;
            nums[i+1] = curr;
        }
    }
}
