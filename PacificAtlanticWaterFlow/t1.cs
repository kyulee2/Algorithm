/*
Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic ocean" touches the right and bottom edges.

Water can only flow in four directions (up, down, left, or right) from a cell to another one with height equal or lower.

Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.

Note:
The order of returned grid coordinates does not matter.
Both m and n are less than 150.
Example:

Given the following 5x5 matrix:

  Pacific ~   ~   ~   ~   ~ 
       ~  1   2   2   3  (5) *
       ~  3   2   3  (4) (4) *
       ~  2   4  (5)  3   1  *
       ~ (6) (7)  1   4   5  *
       ~ (5)  1   1   2   4  *
          *   *   *   *   * Atlantic

Return:

[[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).
*/

// Comment: BFS from each border line upward. Use status array to see if it is visited from Both.

public class Solution {
    List<int[]> ans;
    int[,] m;
    int[,] g; // status 1 for pacific, 2 for atlantic
    int Row;
    int Col;
    void Rec(int i, int j, int val)
    {
  
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[]{i,j, 0});
        while(q.Count != 0)
        {
            int[] n = q.Dequeue();
            int x = n[0];
            int y = n[1];
            int h = n[2];
            if (x<0|| y<0 || x>= Row || y>=Col) continue;
            int status = g[x,y];
            if ((status&val) != 0) continue; // already visited
            
            int curr = m[x,y];
            if (curr< h) continue; // no upward flow for lower
            
            // Set visited and check answer if both visited
            g[x,y] |= val;
            if (g[x,y] == 3)
                ans.Add(new int[]{x,y});
            
            // add next
            q.Enqueue(new int[]{x+1, y, curr});
            q.Enqueue(new int[]{x-1, y, curr});
            q.Enqueue(new int[]{x, y+1, curr});
            q.Enqueue(new int[]{x, y-1, curr});
        }
    }
    
    public IList<int[]> PacificAtlantic(int[,] matrix) {
        // Intialize data
        ans = new List<int[]>();
        m = matrix;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        g = new int[Row, Col];
        
        // Main loop
        // 1. From pacific top/left
        for(int j= 0; j<Col; j++)
            Rec(0,j,1);
        for(int i=1; i<Row; i++)
            Rec(i, 0,1);
        
        // 2. From atlantic bottom/right
        for(int j=0; j<Col; j++)
            Rec(Row-1, j, 2);
        for(int i=0; i<Row-1; i++)
           Rec(i, Col-1, 2);
    
        return ans;
    }
}

