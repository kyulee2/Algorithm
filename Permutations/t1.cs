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
// Comment: Easy
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        int len = nums.Length;
        var t = new int[len];
        var visited = new bool[len];
        var ans = new List<IList<int>>();
        void Rec(int i) {
            if (i==len) {
                ans.Add(new List<int>(t));
                return;
            }
            for(int j=0; j<len; j++) {
                if (visited[j])
                    continue;
                visited[j] = true;
                t[i] = nums[j];
                Rec(i+1);
                visited[j] = false;
            }
        }
        Rec(0);
        return ans;
    }
}
