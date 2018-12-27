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
// Comment: Unlike t1.cs which does DFS with smallest distance update, here use BFS.
// O(mn * max(m,n)) where m, n are row/column length
// When visiting next neighbor, it's not just adjacent cell but it's the cell until the ball hits ball
// where max(m,n) visit occurs for each cell visit.
class Solution {
public:
    vector<vector<int>>* m;
    int Row, Col;
    bool isValid(int i, int j) {
        if (i<0||j<0||i>=Row||j>=Col)
            return false;
        return (*m)[i][j] == 0;
    }
    pair<int, int> getNext(int i, int j, int d) {
        vector<int> t;
        while(true) {
            bool Valid = true;
        switch(d) {
            case 0:
                if (!isValid(i-1,j)) { Valid = false; break; }
                --i; break;
            case 1:
                if (!isValid(i,j+1)) { Valid = false; break; }
                ++j; break;                
            case 2:
                if (!isValid(i+1,j)) { Valid = false; break; }
                ++i; break;                
            case 3:
                if (!isValid(i,j-1)) { Valid = false; break; }
                --j; break;                
        }
            if (!Valid)
                break;
        }
        return make_pair(i, j);
    }
    int shortestDistance(vector<vector<int>>& maze, vector<int>& start, vector<int>& destination) {
        m = &maze;
        Row = maze.size();
        if (Row==0) return -1;
        Col = maze[0].size();
        if (Col==0) return -1;
        vector<vector<int>> visited(Row, vector<int>(Col, -1));
        queue<tuple<int, int, int>> q;
        q.push(make_tuple(start[0], start[1], 0));
        visited[start[0]][start[1]] = 0;

        while(q.size() != 0) {
            auto n = q.front(); q.pop();
            int i = get<0>(n);
            int j = get<1>(n);
            int curr = get<2>(n);

            for(int d = 0; d<4; d++) {
                auto next = getNext(i,j,d);
                int x = next.first;
                int y=  next.second;
                int dist= abs(x - i) + abs(y - j) + curr;
                if (visited[x][y]!=-1 && visited[x][y] <= dist)
                    continue;
                visited[x][y] = dist; // update min here instead of up above.
                q.push(make_tuple(x, y, dist));
            }
        }
               
        return visited[destination[0]][destination[1]];
    }
};
