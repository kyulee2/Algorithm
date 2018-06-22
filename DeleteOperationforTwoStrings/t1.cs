/*
Given two words word1 and word2, find the minimum number of steps required to make word1 and word2 the same, where in each step you can delete one character in either string. 
Example 1:
Input: "sea", "eat"
Output: 2
Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".

Note:
The length of given words won't exceed 500.
Characters in given words can only be lower-case letters.
*/
// Comment: Use DP to get LCS. Subtract two of LCS from the total lengths of two strings.
public class Solution {
    public int MinDistance(string word1, string word2) {
        int Row= word1.Length;
        int Col = word2.Length;
        int[,] d= new int[Row, Col];
        int data(int i, int j) {
            if (i<0 || i>=Row || j<0 ||j>=Col)
                return 0;
            return d[i,j];
        }
        
        int max = 0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                if (word1[i] == word2[j])
                    d[i,j] = data(i-1, j-1) + 1;
                else
                    d[i,j] = Math.Max(data(i-1,j), data(i,j-1));
                max = Math.Max(max, d[i,j]);
            }
        
        return Row + Col - max * 2;
    }
}

