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
public class Solution {
    public IList<IList<int>> FindSubsequences(int[] nums) {
        int len = nums.Length;
        var ans = new List<IList<int>>();
        int i =0, d= 0;

        void Rec(int start, List<int> t)
        {
            if (start>=len)
                return;
            
            var s = new HashSet<int>();
            for(int j = start; j<len; j++) {
                var n = nums[j];
                if (s.Contains(n))
                    continue;
                
                if (t.Count == 0 || t[t.Count-1] <=n) {
                    // Bookkeep to avoid duplication
                    s.Add(n);
                    // Add current number
                    t.Add(n);
                    // Output it if the current sequence is greater than 1
                    if (t.Count>1)
                        ans.Add(new List<int>(t)); // spoiler: clone it
                    Rec(j + 1, t);
                    // Remove current number
                    t.RemoveAt(t.Count-1);
                }
            }
        }
        
        Rec(0, new List<int>());
        return ans;
    }
}