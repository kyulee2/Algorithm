/*
Given strings S and T, find the minimum (contiguous) substring W of S, so that T is a subsequence of W.

If there is no such window in S that covers all characters in T, return the empty string "". If there are multiple such minimum-length windows, return the one with the left-most starting index.

Example 1:
Input: 
S = "abcdebdde", T = "bde"
Output: "bcde"
Explanation: 
"bcde" is the answer because it occurs before "bdde" which has the same length.
"deb" is not a smaller window because the elements of T in the window must occur in order.
Note:

All the strings in the input will only contain lowercase letters.
The length of S will be in the range [1, 20000].
The length of T will be in the range [1, 100].
*/
// Comment: Traditional dynamic programming.
// Put T into Row and S into Col. Consider two arrays - m[,] match count and d[,] distance.
// m[i,j] = T[i]==S[j] ? m[i-1,j-1] + 1 : m[i, j-1]
// d[i,j] = T[i]==S[j] ? d[i-1,j-1] + 1: d[i, j-1] + 1
// Find/update ans for min d[i,j] when m[i,j]=Row for the last Row computation.
public class Solution {
    public string MinWindow(string S, string T) {
        string ans = "";
        int min = 20000;
        int Col = S.Length;
        int Row = T.Length;
        int[,] m = new int[Row,Col];
        int[,] d = new int[Row,Col];
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++) {
                if (T[i]==S[j]) {
                    m[i,j] = (i==0 || j==0) ? 1 : m[i-1,j-1] + 1;
                    d[i,j] = (i==0 || j==0) ? 1 : d[i-1, j-1] + 1;
                }
                else {
                    m[i,j] = j==0 ? 0 : m[i, j-1];
                    d[i,j] = j==0 ? 0 : d[i, j-1] + 1;
                }
                
                if (i==Row-1) {
                    if (m[i,j] == Row && d[i,j] < min) {
                        min = d[i,j];
                        ans = S.Substring(j-d[i,j]+1, d[i,j]);
                    }
                }
            }
        }
        
        return ans;
    }
}


