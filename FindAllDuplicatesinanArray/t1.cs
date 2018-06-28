/*
Given an array of integers, 1 = a[i] = n (n = size of array), some elements appear twice and others appear once.

Find all the elements that appear twice in this array.

Could you do it without extra space and in O(n) runtime?

Example:
Input:
[4,3,2,7,8,2,3,1]

Output:
[2,3]
*/
// Comment: One approach may copy the value on its index. Found it's a bit tricky about the initial index.
// The below approach is quite interesting. Use bookkeeping using negative value.
public class Solution {

    public IList<int> FindDuplicates(int[] nums) {
        var ans = new List<int>();
        int len = nums.Length;
        
        for(int i=0; i<len; i++) {
            if (nums[Math.Abs(nums[i])-1] < 0)
                ans.Add(Math.Abs(nums[i]));
            else
                nums[Math.Abs(nums[i]) -1] *= -1;
        }
        
        return ans;
    }
    
}