/*
A peak element and return its index.
The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
You may imagine that nums[-1] = nums[n] = -Î peak element and return its index.
The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
You may imagine that nums[-1] = nums[n] = -Î
/ mple 1:
Input: nums = [1,2,3,1]
Output: 2
Explanation: 3 is a peak element and your function should return the index number 2.
Example 2:
Input: nums = [1,2,1,3,5,6,4]
Output: 1 or 5 
Explanation: Your function can return either index number 1 where the peak element is 2, 
             or index number 5 where the peak element is 6.
Note:
Your solution should be in logarithmic complexity.

*/

// Comment: It's important to stash potential answer. See comment below.
class Solution {
public:
    int findPeakElement(vector<int>& nums) {
        int ans = 0;
        int len = nums.size();
        if (len==1) return ans;
        
        int i=0, j = len-1;
        while(i<=j) {
            int m = (j-i)/2 + i;
            long prev = m==0 ? (long)INT_MIN-1 : nums[m-1];
            long next = m==len-1 ? (long)INT_MAX+1: nums[m+1];
            long val = nums[m];
            //cout<< val << " " << prev <<" " << next<< endl;
            if (val>prev && val>next)
                return m;
            if (prev < val) {
                ans = m; // Spoiler: Put the candidate to the answer
                i = m+1;
            }
            else
                j = m-1;
        }
        return ans;
    }
};
