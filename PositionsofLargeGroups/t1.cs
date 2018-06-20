/*
In a string S of lowercase letters, these letters form consecutive groups of the same character.
For example, a string like S = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z" and "yy".
Call a group large if it has 3 or more characters.  We would like the starting and ending positions of every large group.
The final answer should be in lexicographic order.
 
Example 1:
Input: "abbxxxxzzy"
Output: [[3,6]]
Explanation: "xxxx" is the single large group with starting  3 and ending positions 6.
Example 2:
Input: "abc"
Output: []
Explanation: We have "a","b" and "c" but no large group.
Example 3:
Input: "abcdddeeeeaabbbcd"
Output: [[3,5],[6,9],[12,14]]
*/
// Comment: Easy, but carefule about increment ahead (i++) below.
// The above condition in lexicographic order is not actually applied in test.
public class Solution {
    public IList<IList<int>> LargeGroupPositions(string S) {
        var ans = new List<IList<int>>();
        int len = S.Length;
        int i=0;
        
        while(i<len) {
            char c = S[i];
            int start = i;
            i++;
            while(i<len && c == S[i]) i++;
            int end = i - 1;
            if (i - start >= 3) {
                var l = new List<int>();
                l.Add(start); l.Add(end);
                ans.Add(l);
            }            
        }
        
        return ans;
    }
}

