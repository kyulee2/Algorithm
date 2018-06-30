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
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var ans = new List<IList<int>>();
        int len = nums.Length;
        void Rec(int i, List<int> l)
        {
            if (i==len) {
                ans.Add(l);
                return;
            }
            var n = nums[i];
            var nextL = new List<int>(l);
            nextL.Add(n);
            Rec(i+1, nextL);
            Rec(i+1, l);
        }
        Rec(0, new List<int>());
        return ans;
    }
}
