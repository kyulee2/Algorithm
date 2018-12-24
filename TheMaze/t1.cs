/*
There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.
Given the ball's start position, the destination and the maze, determine whether the ball could stop at the destination.
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

Output: true
Explanation: One possible way is : left -> down -> left -> down -> right -> down -> right.


Example 2 
Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (3, 2)

Output: false
Explanation: There is no way for the ball to stop at the destination.


Note:
There is only one ball and one destination in the maze.
Both the ball and the destination exist on an empty space, and they will not be at the same position initially.
The given maze does not contain border (like the red rectangle in the example pictures), but you could assume the border of the maze are all walls.
The maze contains at least 2 empty spaces, and both the width and height of the maze won't exceed 100.
*/

// Comment: Don't foget use cache. Otherwise it will fail due to time-limit.
// Since it's boolean result, as blow, the cache/map contains 1 (true) or 2 (false) while 0 means not prior results.
// Also enum in c# always use its type -- not just Up, but Direction.Up
public class Solution {
    enum Direction {
        Up,
        Down,
        Left,
        Right
    }
    int[,] m;
    int Row;
    int Col;
    int[] d;
    bool[,] visited;
    int[,] map;
    
    bool isValid(int i, int j)
    {
        if (i<0||j<0||i>=Row||j>=Col)
            return false;
        return m[i,j] == 0;
    }
    
    int[] getNext(int i, int j, Direction d)
    {
        switch(d) {
            case Direction.Up:
                while(isValid(i,j)) --i;
                return new int[]{i+1, j};
            case Direction.Down:
                while(isValid(i,j)) ++i;
                return new int[]{i-1, j};
            case Direction.Left:
                while(isValid(i,j)) --j;
                return new int[]{i, j+1};
            case Direction.Right:
                while(isValid(i,j)) ++j;
                return new int[]{i, j-1};
        }
        
        return null;
    }
    
    bool Rec(int[] n)
    {
        int i= n[0];
        int j= n[1];
        
        if (i ==d[0] && j == d[1])
            return true;
        // Spoiler: check cache

        if (map[i,j] > 0)
            return map[i,j] == 1;
        if (map[i,j] < 0) /// combined visited check
            return false;
        map[i,j] = -1; // visited; This can't be hoisted above map[i,j]>0 check.. This will be overwritten after all child recursion is done below.        

        bool ans = false;
        if (isValid(i+1, j))
            ans |= Rec(getNext(i+1, j, Direction.Down));
        if (isValid(i-1, j))
            ans |= Rec(getNext(i-1, j, Direction.Up));
        if (isValid(i, j+1))
            ans |= Rec(getNext(i, j+1, Direction.Right));
        if (isValid(i, j-1))
            ans |= Rec(getNext(i, j-1, Direction.Left));        
        
        map[i,j] = ans ? 1 : 2;
        return ans;
    }

    public bool HasPath(int[,] maze, int[] start, int[] destination) {
        // Initialize data
        m = maze;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        d = destination;
        visited = new bool[Row, Col];
        map = new int[Row, Col];
        
        return Rec(start);
    }
}


