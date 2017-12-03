/*
Medium: Permutation II

Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[
  [1,1,2],
  [1,2,1],
  [2,1,1]
]
*/
public class Solution {
    IList<IList<int>> sol;
    bool[] used;
    int[] curr;
    public IList<IList<int>> PermuteUnique(int[] nums) {
        sol = new List<IList<int>>();
        int n = nums.Length;
        used = new bool[n];
        curr = new int[n];
        
        // Sort array to handle duplications
        Array.Sort(nums);
        
        Rec(nums, 0);
        
        return sol;
    }
    
    void Rec(int[] nums, int s)
    {
        int n = nums.Length;
        if (s == n)
        {
            List<int> a = new List<int>();
            foreach(var e in curr)
                a.Add(e);
            sol.Add(a);
            return;
        }
        
        for (int i = 0; i < n; i++)
        {
            if (used[i]) continue;
            // Detect duplication
            if (i > 0 && !used[i-1] && (nums[i-1] == nums[i]))
                continue;
            used[i] = true;
            curr[s] = nums[i];
            Rec(nums, s+1);
            used[i] = false;
        }
    }
}

