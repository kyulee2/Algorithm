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
    int[,] cost;
    int[,] visited; // status how many costs are updated
    int Row;
    int Col;
    int[,] g;
    int b; // Current building count/id
    
    class Node {
        public int i;
        public int j;
        public int d; // depth/path length
        public Node(int a, int b, int c)
        {
            i = a; j= b; d = c;
        }
    }
    void Rec(int x, int y, int d)
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(new Node(x, y, d));
        bool[,] t = new bool[Row,Col]; // For checking visited node for the current building
        
        while(q.Count != 0) {
            Node n = q.Dequeue();
            int i = n.i;
            int j = n.j;
            int depth = n.d;
            
            if (i<0 || i>= Row || j<0 || j>=Col) continue;
            if (g[i,j] != 0 || t[i,j]) continue;        
    
            t[i,j] = true;
            visited[i,j]++;
            cost[i,j] += depth;
            
            q.Enqueue(new Node(i+1, j, depth+1));
            q.Enqueue(new Node(i-1, j, depth+1));
            q.Enqueue(new Node(i, j+1, depth+1));
            q.Enqueue(new Node(i, j-1, depth+1));
        }
    }

    public int ShortestDistance(int[,] grid) {        
        int ans = Int32.MaxValue;
        
        // Initialize data
        b = 0; // total buildings
        g = grid;
        Row = grid.GetLength(0);
        Col = grid.GetLength(1);
        cost = new int[Row, Col];
        visited = new int[Row, Col];
        
        // Main loop: update cost via DFS from each building
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if(g[i,j] == 1) {
                    b++;
                    g[i,j] = 0;
                    Rec(i,j, 0);
                    g[i,j] = 1;
                }
        
        // Find the lowest cost
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++) {
                if(g[i,j] == 0 && visited[i,j] == b) {
                    if (cost[i,j] < ans)
                        ans = cost[i,j];
                }
            }
        }        
        
        return ans == Int32.MaxValue ? -1 : ans;        
    }
}
