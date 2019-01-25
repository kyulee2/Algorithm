/*
Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.
Note:
The solution set must not contain duplicate quadruplets.
Example:
Given array nums = [1, 0, -1, 0, -2, 2], and target = 0.

A solution set is:
[
  [-1,  0, 0, 1],
  [-2, -1, 1, 2],
  [-2,  0, 0, 2]
]
*/
// Comment: Check the prior value to avoid duplication. O(n^3)
class Solution {
public:
    vector<vector<int>> fourSum(vector<int>& nums, int target) {
        sort(nums.begin(), nums.end());
        int len = nums.size();
        vector<vector<int>> ans;
        for(int i=0; i<len-3; i++) {
            if (i!=0 && nums[i-1]==nums[i])
                continue;
            for(int j=i+1; j<len-2; j++) {
                if (j!=i+1 && nums[j-1]==nums[j])
                    continue;
                int k = j+1, l = len-1;
                while(k<l) {
                    if (k!=j+1 && nums[k-1]==nums[k]) {
                        k++;continue;
                    }
                    if (l!=len-1 && nums[l]==nums[l+1]) {
                        l--;continue;
                    }
                    int sum = nums[i]+nums[j]+nums[k]+nums[l];
                    if (sum == target) {
                        vector<int> t = {nums[i], nums[j], nums[k], nums[l]};
                        ans.push_back(t);
                        k++; l--;
                    } else if (sum > target)
                        l--;
                    else k++;
                }
            }
        }
        
        return ans;
    }
};