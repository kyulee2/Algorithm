/*
There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.
Given the ball's start position, the destination and the maze, find the shortest distance for the ball to stop at the destination. The distance is defined by the number of empty spaces traveled by the ball from the start position (excluded) to the destination (included). If the ball cannot stop at the destination, return -1.
The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The start and destination coordinates are represented by row and column indexes.
Example 1 
Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (4, 4)

Output: 12
Explanation: One shortest way is : left -> down -> left -> down -> right -> down -> right.
             The total distance is 1 + 1 + 3 + 1 + 2 + 2 + 2 = 12.


Example 2 
Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (3, 2)

Output: -1
Explanation: There is no way for the ball to stop at the destination.


Note:
There is only one ball and one destination in the maze.
Both the ball and the destination exist on an empty space, and they will not be at the same position initially.
The given maze does not contain border (like the red rectangle in the example pictures), but you could assume the border of the maze are all walls.
The maze contains at least 2 empty spaces, and both the width and height of the maze won't exceed 100.
*/
// Comment: DFS with smallest distance update.
// O(mn * max(m,n)) where m, n are row/column length
// When visiting next neighbor, it's not just adjacent cell but it's the cell until the ball hits ball
// where max(m,n) visit occurs for each cell visit.
// There are other ways BFS/Dikstra, etc. see solution
public class Solution {
    public int ShortestDistance(int[,] maze, int[] start, int[] destination) {
        int Row = maze.GetLength(0);
        int Col = maze.GetLength(1);
        var map = new int[Row, Col];
        
        int ans = -1;
        bool isLegal(int i, int j)
        {
            return i>=0 && i<Row && j>=0 && j<Col && maze[i,j] == 0;
        }
        
        // Return next position for the given direction 0 (north) 1 (east) 2(south) 3 (west)
        // until the ball hits the wall (can't move)
        // Returns move count as well.
        int[] getNext(int i, int j, int d)
        {
            int cnt = 0;
            int x = i, y=j;
            while(isLegal(x,y)) {
                i = x; j = y;
                switch(d) {
                    case 0: x = i - 1; break;
                    case 1: y = j + 1; break;
                    case 2: x = i + 1; break;
                    case 3: y = j - 1; break;
                }
                cnt++;
            }
            if (cnt==0)
                return null;
            return new int[3]{i,j,cnt-1};
        }
        
        void Rec(int i, int j, int dist) {
            if (map[i,j]<=dist)
                return;
            map[i,j] = dist;
            if (i==destination[0] && j==destination[1]) {
                ans = dist;
                return;
            }
            for(int k=0; k<4; k++) {
                var n = getNext(i,j, k);
                if (n== null) continue;
                Rec(n[0], n[1], dist + n[2]);
            }
        }
        
        // Init map with max distance
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                map[i,j] = Int32.MaxValue;

        Rec(start[0], start[1], 0);
        
        return ans;
    }
}