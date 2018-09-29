/*
Given a grid where each entry is only 0 or 1, find the number of corner rectangles.
A corner rectangle is 4 distinct 1s on the grid that form an axis-aligned rectangle. Note that only the corners need to have the value 1. Also, all four 1s used must be distinct.
 
Example 1:
Input: grid = 
[[1, 0, 0, 1, 0],
 [0, 0, 1, 0, 1],
 [0, 0, 0, 1, 0],
 [1, 0, 1, 0, 1]]
Output: 1
Explanation: There is only one corner rectangle, with corners grid[1][2], grid[1][4], grid[3][2], grid[3][4].
 
Example 2:
Input: grid = 
[[1, 1, 1],
 [1, 1, 1],
 [1, 1, 1]]
Output: 9
Explanation: There are four 2x2 rectangles, four 2x3 and 3x2 rectangles, and one 3x3 rectangle.
 
Example 3:
Input: grid = 
[[1, 1, 1, 1]]
Output: 0
Explanation: Rectangles must have four distinct corners.
 
Note:
The number of rows and columns of grid will each be in the range [1, 200].
Each grid[i][j] will be either 0 or 1.
The number of 1s in the grid will be at most 6000.
*/
// Comment: Track with two columns has 1 forming two top corners.
// For each row, tracking such counts. Adding up such counts ends up with answer.
// After adding up such count and update map -- say Map(c1,c2) = n means there are n counts where c1 and c2 columns both have 1. The total count of rectangles are n(n-1)/2 = sum of 1 ~ n-1.
// O(R C^2) where R is row and C is column.
public class Solution {
    public int CountCornerRectangles(int[,] grid) {
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);
        var map = new int[Col,Col]; // tracking count of coreners at c1, c2 column
        int ans = 0;
        for(int i=0; i< Row; i++) {
            for(int c1 = 0; c1<Col-1; c1++) {
                if (grid[i,c1] != 1) continue;
                for(int c2 = c1+1; c2<Col; c2++) {
                    if (grid[i,c2]!=1) continue;
                    var count = map[c1,c2];
                    ans += count; // adding up accumulation 1 + 2 + 3 ....
                    map[c1,c2] = count + 1;
                }
            }
        }
        
        return ans;
    }
}