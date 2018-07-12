/*
Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.

You have the following 3 operations permitted on a word:

Insert a character
Delete a character
Replace a character
Example 1:

Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')
Example 2:

Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')
*/
// Comment: Traditional DP. Th below is based on Rec + memoization.
public class Solution {
    public int MinDistance(string word1, string word2) {
        int len1 = word1.Length;
        int len2 = word2.Length;
        int[,] d = new int[len1+1, len2+1];
        for(int i=0; i<=len1; i++)
            for(int j=0; j<=len2; j++)
                d[i,j] = -1;
        
        int Rec(int i, int j)
        {
            if (d[i,j]!=-1)
                return d[i,j];
            
            if (i==0 || j==0) {
                d[i,j] = Math.Max(i,j);
                return d[i,j];
            }
            
            int ans = 0;
            if (word1[i-1] == word2[j-1])
                ans = Rec(i-1, j-1);
            else
                ans = Math.Min(Math.Min(Rec(i-1, j), Rec(i,j-1)), Rec(i-1,j-1)) + 1;
            d[i,j] = ans;
            
            return ans;
        }
        
        return Rec(len1, len2);
    }
}
