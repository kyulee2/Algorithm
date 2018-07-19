/*
A group of two or more people wants to meet and minimize the total travel distance. You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.
Example:
Input: 

1 - 0 - 0 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0

Output: 6 

Explanation: Given three people living at (0,0), (0,4), and (2,2):
             The point (0,2) is an ideal meeting point, as the total travel distance 
             of 2+2+2=6 is minimal. So return 6.
*/
// Comment: Similar to Shortest Distance from All buildings.
// This fails due to TLE (56/57) pass
public class Solution {
    public int MinTotalDistance(int[,] grid) {
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);
        // Spoiler: Can't repurose grid to handle 0 distance from people location itself.
        var g = new int[Row, Col];
        void Rec(int i, int j)
        {
            var q = new Queue<int[]>();
            q.Enqueue(new int[]{i,j,0});
            var visited = new bool[Row, Col];
            while(q.Count != 0) {
                var n = q.Dequeue();
                int x = n[0], y = n[1], d = n[2];
                if (x<0||y<0||x>=Row||y>=Col) continue;
                if (visited[x,y]) continue;
                visited[x,y] = true;
                g[x,y] += d;
                q.Enqueue(new int[]{x+1, y, d+1});
                q.Enqueue(new int[]{x-1, y, d+1});
                q.Enqueue(new int[]{x, y+1, d+1});
                q.Enqueue(new int[]{x, y-1, d+1});
            }
        }
        
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (grid[i,j] == 1)
                    Rec(i,j);
        
        int min = Int32.MaxValue;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                min=  Math.Min(min, g[i,j]);
        
        return min;
    }
}
