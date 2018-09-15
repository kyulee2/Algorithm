/*
In a 2 dimensional array grid, each value grid[i][j] represents the height of a building located there. We are allowed to increase the height of any number of buildings, by any amount (the amounts can be different for different buildings). Height 0 is considered to be a building as well. 
At the end, the "skyline" when viewed from all four directions of the grid, i.e. top, bottom, left, and right, must be the same as the skyline of the original grid. A city's skyline is the outer contour of the rectangles formed by all the buildings when viewed from a distance. See the following example.
What is the maximum total sum that the height of the buildings can be increased?
Example:
Input: grid = [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
Output: 35
Explanation: 
The grid is:
[ [3, 0, 8, 4], 
  [2, 4, 5, 7],
  [9, 2, 6, 3],
  [0, 3, 1, 0] ]

The skyline viewed from top or bottom is: [9, 4, 8, 7]
The skyline viewed from left or right is: [8, 7, 9, 3]

The grid after increasing the height of buildings without affecting skylines is:

gridNew = [ [8, 4, 8, 7],
            [7, 4, 7, 7],
            [9, 4, 8, 7],
            [3, 3, 3, 3] ]

*/
// Comment: Understand problem first. Skyline means the highest building that appears from the current location -- the one touches sky?
// Eacy building can increase its height up to minium of skyline from top/bottom and skyline from left/right to maintain as the same skylines as before.
public class Solution {
    public int MaxIncreaseKeepingSkyline(int[][] grid) {
        int Row = grid.Length;
        int Col = grid[0].Length;
        // get skyline for Row and Col
        var Rows = new int[Row];
        var Cols = new int[Col];
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                Rows[i] = Math.Max(Rows[i], grid[i][j]);
                Cols[j] = Math.Max(Cols[j], grid[i][j]);
            }
        
        // main loop for sum
        int ans =0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                int min = Math.Min(Rows[i], Cols[j]);
                ans += (min - grid[i][j]);
            }
        
        return ans;
    }
}
