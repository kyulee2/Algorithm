/*
Given an integer array, your task is to find all the different possible increasing subsequences of the given array, and the length of an increasing subsequence should be at least 2 . 
Example:
Input: [4, 6, 7, 7]
Output: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7], [4,7,7]]

Note:
The length of the given array will not exceed 15.
The range of integer in the given array is [-100,100].
The given array may contain duplicates, and two equal integers should also be considered as a special case of increasing sequence.
*/
// Comment: Should be DFS recursion. But it's important to detect duplication.
// Using hashset to detect the entire sequence list/array doesn't work.
// Instead, for each recursion level, use a separate hashset to skip the repeated number.
// E.g, [4,6,7] (at first iteration on recursion 3) vs. [4,6,7] (at second iteration on recursion 3) where the latter is skipped. Note [4,6,7,7] (on recursion 4) still counts.
class Solution {
public:
    vector<vector<int>> findSubsequences(vector<int>& nums) {
        vector<vector<int>> ans;
        vector<int> t2;
        std::function<void(vector<int>&,int)> rec = [&rec, &ans,nums](vector<int>& t, int start)->void {
            if (start==nums.size())
                return;
            set<int> s;
            for(int i=start; i<nums.size(); i++) {
                auto n = nums[i];
                if (s.find(n)!=s.end())
                    continue;
                if (t.size()==0 || t.back()<=n) {
                    s.insert(n);
                    t.push_back(n);
                    if (t.size()>1)
                        ans.push_back(t);
                    rec(t, i+1);
                    t.pop_back();
                } 
            }
        };
        rec(t2, 0);
        return ans;
    }
};
