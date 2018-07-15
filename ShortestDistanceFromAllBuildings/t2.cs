/*
You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, where:
Each 0 marks an empty land which you can pass by freely.
Each 1 marks a building which you cannot pass through.
Each 2 marks an obstacle which you cannot pass through.
Example:
Input: [[1,0,2,0,1],[0,0,0,0,0],[0,0,1,0,0]]

1 - 0 - 2 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0

Output: 7 

Explanation: Given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2),
             the point (1,2) is an ideal empty land to build a house, as the total 
             travel distance of 3+3+1=7 is minimal. So return 7.
Note:
There will be at least one building. If it is not possible to build such house according to the above rules, return -1.
*/
// Comment: The key idea is to record all distance on 0 node from each building by recursively walk.
// There are many spoilers.
// 1. It's BFS not DFS. Use a queue instead of recursion.
// 2. Should record cost per building id or something. This is different than just checking node is visited.
//    In below, I use two different arrays -- one for visited and the other is t that is allocated for every building.
public class Solution {
    int[,] visited; // status how many costs are updated
    int Row;
    int Col;
    int[,] g;
    int b;

    void Rec(int i, int j)
    {
        var q = new Queue<int[]>();
        q.Enqueue(new int[]{i+1,j,1});
        q.Enqueue(new int[]{i-1,j,1});
        q.Enqueue(new int[]{i,j+1,1});
        q.Enqueue(new int[]{i,j-1,1});
        
	// Spoiler: checking visited node
        var t = new bool[Row,Col];
        while(q.Count != 0) {
            var n = q.Dequeue();
            int x = n[0];
            int y =n[1];
            int z = n[2];
            if (x<0||y<0 || x>=Row||y>=Col || g[x,y]>0)
                continue;
            if (t[x,y])
                continue;
            t[x,y] = true;
            
            ++visited[x,y];
            g[x,y] -= z;
            
            q.Enqueue(new int[]{x+1, y, z+1});
            q.Enqueue(new int[]{x-1, y, z+1});
            q.Enqueue(new int[]{x, y+1, z+1});
            q.Enqueue(new int[]{x, y-1, z+1});                
        }
    }
    
    public int ShortestDistance(int[,] grid) {        
        int ans = Int32.MaxValue;
        
        // Initialize data
        b = 0; // total buildings
        g = grid;
        Row = grid.GetLength(0);
        Col = grid.GetLength(1);
        visited = new int[Row, Col];
        
        // Main loop: update cost via DFS from each building
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if(g[i,j] == 1) {
                    b++;
                    Rec(i,j);
                }
        
        // Find the lowest cost
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++) {
                if(g[i,j] < 0 && visited[i,j] == b)
                    ans = Math.Min(ans, -g[i,j]);
            }
        }        
        
        return ans == Int32.MaxValue ? -1 : ans;        
    }
}

