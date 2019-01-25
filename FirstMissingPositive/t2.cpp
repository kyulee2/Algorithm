/*
Given an unsorted integer array, find the smallest missing positive integer.
Example 1:
Input: [1,2,0]
Output: 3
Example 2:
Input: [3,4,-1,1]
Output: 2
Example 3:
Input: [7,8,9,11,12]
Output: 1
Note:
Your algorithm should run in O(n) time and uses constant extra space.
*/
// Comment: A bit tricky. When not fodund, returning the len + 1 below.
// Unlike t1.cs, the below use negative value to indicate the position is occupied.
class Solution {
public:
    int firstMissingPositive(vector<int>& nums) {
        for(auto &n : nums)
            --n;
        bool HasOne = false;
        for(auto &n : nums) {
            if (n==0) HasOne = true;
            if (n<=0)
                n = INT_MAX;
        }
        if (!HasOne) return 1;
        for(int i=0; i<nums.size(); i++) {
            int j = (int)abs(nums[i]);
            if (j<nums.size() && nums[j] >0)
                nums[j] =-nums[j];
        }
        for(int i=1; i<nums.size(); i++) {
            int j=  nums[i];
            //cout<<j<<endl;
            if (j >0)
                return i+1;
        }
        return nums.size()+1;
    }
};
