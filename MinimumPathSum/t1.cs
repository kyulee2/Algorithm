/*
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example:

Input:
[
  [1,3,1],
  [1,5,1],
  [4,2,1]
]
Output: 7
Explanation: Because the path 1,3,1,1,1 minimizes the sum.
*/
// Comment: One spoiler about 0,0 for sum. Also consider max value for out of range value.
public class Solution {
    public int MinPathSum(int[,] grid) {
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);
        var Sum = new int[Row, Col];
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                // Spoiler: 0,0 handle speically
                if (i==0 && j==0) Sum[i,j] = grid[i,j];
                else
                Sum[i,j] = Math.Min(i==0? Int32.MaxValue : Sum[i-1,j], j==0?Int32.MaxValue:Sum[i,j-1]) + grid[i,j];
            }
        return Sum[Row-1, Col-1];
    }
}
