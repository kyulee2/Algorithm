/*
You are given a m x n 2D grid initialized with these three possible values.
-1 - A wall or an obstacle.
0 - A gate.
INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.
Example: 
Given the 2D grid:
INF  -1  0  INF
INF INF INF  -1
INF  -1 INF  -1
  0  -1 INF INF
After running your function, the 2D grid should be:
  3  -1   0   1
  2   2   1  -1
  1  -1   2  -1
  0  -1   3   4
*/
// Comment: Simple BFS from gate. Don't need visited side-table. Once we found minimal distance, stop recursion.
public class Solution {
    int Row;
    int Col;
    int[,] r;
    bool isValid(int i, int j)
    {
        if (i<0 || i>=Row || j<0 || j>=Col)
            return false;
        return r[i,j] !=-1 && r[i,j] != 0;
    }
    void Rec(int i, int j)
    {
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[]{i+1, j, 1});
        q.Enqueue(new int[]{i-1, j, 1});
        q.Enqueue(new int[]{i, j+1, 1});
        q.Enqueue(new int[]{i, j-1, 1});
        while(q.Count >0) {
            int[] n = q.Dequeue();
            int x = n[0];
            int y = n[1];
            int d = n[2];
            if (!isValid(x,y)) continue;
            if (r[x,y]<=d) continue; // already has the shortest distance
            r[x,y] = d;
            // visit neighbors
            q.Enqueue(new int[]{x+1, y, d+1});
            q.Enqueue(new int[]{x-1, y, d+1});
            q.Enqueue(new int[]{x, y+1, d+1});
            q.Enqueue(new int[]{x, y-1, d+1});
        }
    }
        
    public void WallsAndGates(int[,] rooms) {
        Row = rooms.GetLength(0);
        Col = rooms.GetLength(1);
        r = rooms;
        for(int i= 0; i<Row; i++)
            for(int j= 0; j<Col; j++)
                if (rooms[i,j] == 0)
                    Rec(i,j);
    }
}

