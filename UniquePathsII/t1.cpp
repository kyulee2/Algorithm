/*
A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

Now consider if some obstacles are added to the grids. How many unique paths would there be?



An obstacle and empty space is marked as 1 and 0 respectively in the grid.

Note: m and n will be at most 100.

Example 1:

Input:
[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
Output: 2
Explanation:
There is one obstacle in the middle of the 3x3 grid above.
There are two ways to reach the bottom-right corner:
1. Right -> Right -> Down -> Down
2. Down -> Down -> Right -> Right
*/
// Comment: Simple DFS/BFS will result in TLE.
// DP (cache) to # of ways that come from either up (i-1) or left (j-1)
// Don't forget initilizing (0,0) either 0 or 1 depending on its obstacle
class Solution {
public:
    
    int uniquePathsWithObstacles(vector<vector<int>>& obstacleGrid) {
        int Row = obstacleGrid.size();
        if (Row==0) return 0;
        int Col = obstacleGrid[0].size();
        vector<vector<int>> dist(Row, vector<int>(Col));
        
        auto isValid = [Row, Col, &obstacleGrid](int i, int j) {
            if (i<0|| j<0 || i>=Row || j>=Col)
                return false;
            return obstacleGrid[i][j]==0;
        };
        // Important to initialize the first element, or everything is 0
        dist[0][0] = obstacleGrid[0][0] ==0 ? 1 : 0;

        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                if (!isValid(i,j))
                    continue;
                if (i==0 && j==0)
                    continue; // skip 0,0 which has been taken care of
                
                auto up = isValid(i-1, j) ? dist[i-1][j] : 0;
                auto left = isValid(i, j-1) ? dist[i][j-1] : 0;
                dist[i][j] = up + left;
            }
        return dist[Row-1][Col-1];
    }
};
