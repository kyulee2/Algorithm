/*
Given a collection of distinct integers, return all possible permutations.

Example:

Input: [1,2,3]
Output:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
*/
// Comment: Swap method.
class Solution {
public:
    vector<vector<int>> ans;
    void swap(vector<int>& nums, int i, int j) {
        auto t = nums[i];
        nums[i] = nums[j];
        nums[j]= t;
    }
    void Rec(vector<int>& nums, int i, int j)
    {
        if (i==j) {
            ans.push_back(vector<int>(nums));
            return;
        }
        for(int k=i; k<=j; k++) {
            swap(nums, i,k);
            Rec(nums, i+1, j);
            swap(nums, i,k);
        }
        
    }
    vector<vector<int>> permute(vector<int>& nums) {
        Rec(nums, 0, nums.size()-1);
        return ans;
    }
};