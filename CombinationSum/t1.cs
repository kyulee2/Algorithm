/*
Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

The same repeated number may be chosen from candidates unlimited number of times.

Note:

All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
Example 1:

Input: candidates = [2,3,6,7], target = 7,
A solution set is:
[
  [7],
  [2,2,3]
]
Example 2:

Input: candidates = [2,3,5], target = 8,
A solution set is:
[
  [2,2,2,2],
  [2,3,3],
  [3,5]
]
*/
// Comment: Traditional but cautious of recursion
// The former is simpler though both work
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        
        int len = candidates.Length;
        var t = new List<int>();
        var ans = new List<IList<int>>();
        
        void Rec(int idx, int tgt) {
            if (tgt == 0) {
                ans.Add(new List<int>(t));
                return; 
            }
            
            for(int i=idx; i<len; i++) // stars from idx to handle duplicated selection
            {
                if (tgt >= candidates[idx]) {
                    t.Add(candidates[i]);
                    Rec(i, tgt - candidates[i]);
                    t.RemoveAt(t.Count - 1);
                } else break;
            }
        }
        
        Rec(0, target);
        
        return ans;
    }
}

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        int len = candidates.Length;
        var t = new int[target/candidates[0] + 1];
        var ans = new List<IList<int>>();
        
        void Rec(int idx, int depth, int tgt) {
            if (candidates[idx] > tgt) return ;
            t[depth++] = candidates[idx];
            if (candidates[idx] == tgt) {
                var ta = new int[depth];
                Array.Copy(t, 0, ta, 0, depth);
                ans.Add(ta);
                return;
            }
            
            for(int i=idx; i<len; i++)
                Rec(i, depth, tgt - candidates[idx]);
        }
        
        for(int j=0; j<len; j++) {
            Rec(j, 0, target);
        }
        
        return ans;
    }
}
