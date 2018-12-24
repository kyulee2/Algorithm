/*
Given a set of distinct integers, nums, return all possible subsets (the power set).

Note: The solution set must not contain duplicate subsets.

Example:

Input: nums = [1,2,3]
Output:
[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
  [1,2],
  []
]
*/ 
// Comment: Easy
class Solution {
public:
    int len;
    vector<vector<int>> ans;
    void Rec(vector<int>& nums, vector<int>&curr, int i)
    {
        if (i==len)
            ans.push_back(vector<int>(curr));
        else {
            curr.push_back(nums[i]);
            Rec(nums, curr, i+1);
            curr.pop_back();
            Rec(nums, curr, i+1);
        }
        
    }
    vector<vector<int>> subsets(vector<int>& nums) {
        len = nums.size();
        vector<int> curr;
        Rec(nums, curr, 0);
        return ans;
    }
};
