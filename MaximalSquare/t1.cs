/*
Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
Example:
Input: 

1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0

Output: 4
*/
// Comment: A bit interesting simple DP. The below is O(mn) for both space and time
// Think about how to define the length of squre.
public class Solution {
    public int MaximalSquare(char[,] matrix) {
        // DP: set D(i,j) is th length of square at the bottom, right corner (i,j)
        int Row = matrix.GetLength(0);
        int Col = matrix.GetLength(1);
        int maxL = 0;
        var d = new int[Row+1, Col+1];
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (matrix[i,j] == '1') {
                    d[i+1,j+1] = Math.Min(d[i,j+1], Math.Min(d[i+1, j], d[i,j])) + 1;
                    maxL = Math.Max(maxL, d[i+1,j+1]);
                }
        
        return maxL * maxL;
    }
}