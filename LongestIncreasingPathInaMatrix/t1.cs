/*
Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:

Input: nums = 
[
  [9,9,4],
  [6,6,8],
  [2,1,1]
] 
Output: 4 
Explanation: The longest increasing path is [1, 2, 6, 9].
Example 2:

Input: nums = 
[
  [3,4,5],
  [3,2,6],
  [2,2,1]
] 
Output: 4 
Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
*/

// Comment: This is DFS not BFS. So, visited status is required which should be flipped on and off. Without cacheing, it's time-out.

public class Solution {
    int Row;
    int Col;
    bool[,] visited;
    int[,] m;
    int max;
    int[,] map;
    
    int Rec(int i, int j, int val)
    {
        if (i<0||j<0||i>=Row||j>=Col)
            return 0;
        if (visited[i,j]) return 0;
        int n = m[i,j];
        if (n<=val) return 0;
        
        // Use cache
        if (map[i, j] !=0) return map[i,j];
        
        visited[i,j] = true;
        
        int u = Rec(i-1, j, n);
        int d = Rec(i+1, j, n);

        int l = Rec(i, j-1, n);
        int r = Rec(i, j+1, n);
        
        int len = Math.Max(u, d);
        len = Math.Max(len, l);
        len = Math.Max(len, r);
        len++;
        if (len > max) max = len;
        visited[i,j] = false;
        
        map[i,j] = len;
        
        return len;
     }
    
    public int LongestIncreasingPath(int[,] matrix) {
        // Initialize data
        m = matrix;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        max = 0;
        visited = new bool[Row, Col];
        map = new int[Row, Col];
        
        // main loop
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                Rec(i,j, Int32.MinValue);
            }
        
        return max;
    }
}

