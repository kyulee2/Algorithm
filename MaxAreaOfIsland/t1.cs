/*
Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

Example 1:
[[0,0,1,0,0,0,0,1,0,0,0,0,0],
 [0,0,0,0,0,0,0,1,1,1,0,0,0],
 [0,1,1,0,1,0,0,0,0,0,0,0,0],
 [0,1,0,0,1,1,0,0,1,0,1,0,0],
 [0,1,0,0,1,1,0,0,1,1,1,0,0],
 [0,0,0,0,0,0,0,0,0,0,1,0,0],
 [0,0,0,0,0,0,0,1,1,1,0,0,0],
 [0,0,0,0,0,0,0,1,1,0,0,0,0]]
Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
Example 2:
[[0,0,0,0,0,0,0,0]]
Given the above grid, return 0.
Note: The length of each dimension in the given grid does not exceed 50
*/
// Comment: Easy/straightforward.
public class Solution {
    public int MaxAreaOfIsland(int[,] grid) {
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);
        int getArea(int i, int j) {
            if (i<0||i>=Row||j<0||j>=Col)
                return 0;
            if (grid[i,j] != 1)
                return 0;
            grid[i,j] = 2;
            return 1 + getArea(i+1, j) + getArea(i-1, j) + getArea(i,j+1) + getArea(i,j-1);
        }
        int max = 0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                max =Math.Max(max, getArea(i,j));
        
        return max;
    }
}

