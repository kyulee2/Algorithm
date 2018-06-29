/*
Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:

The solution set must not contain duplicate triplets.

Example:

Given array nums = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
*/
// Comment: Use sorted array and hashset to avoid duplication. 
// Note even though the answer is found, should search continuously below.
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var ret = new HashSet<Tuple<int,int,int>>();
        void find(int x, int y, int k) {
            while(x<y) {
                int l = nums[x];
                int r = nums[y];
                if (l+r == k) {
                    ret.Add( new Tuple<int,int,int>(-k, l, r));
                    // continue search
                    x++;
                    y--;
                } else if (l+r < k)
                    x++;
                else y--;
            }
        }
        
        Array.Sort(nums);
        int len = nums.Length;
        
        for(int i=0; i <len -2;i++) {
            // Avoid duplication
            //if (i>0 && nums[i-1] == nums[i])
            //    continue;
            find(i+1, len-1, -nums[i]);
        }
        
        var ans = new List<IList<int>>();
        foreach(var v in ret) {
            var t = new List<int>() {v.Item1, v.Item2, v.Item3};
            ans.Add(t);
        }
        return ans;
    }
}

