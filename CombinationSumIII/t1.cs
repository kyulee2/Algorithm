/*
Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.
Note:
All numbers will be positive integers.
The solution set must not contain duplicate combinations.
Example 1:
Input: k = 3, n = 7
Output: [[1,2,4]]
Example 2:
Input: k = 3, n = 9
Output: [[1,2,6], [1,3,5], [2,3,4]]
*/
// Comment: Combination not permutation. No need visited, but use start for next iteration in next recursion.
public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var ans = new List<IList<int>>();
        var t = new int[k];
        void Rec(int num, int i, int start) {
            if (i==k) {
                if (num==0)
                    ans.Add(new List<int>(t));
                return;
            }
            
            for(int j=start; j<=9; j++) {
                if (num<j) break;
                t[i] = j;
                Rec(num-j, i+1, j+1);
            }
        }
        Rec(n, 0, 1);
        
        return ans;
    }
}