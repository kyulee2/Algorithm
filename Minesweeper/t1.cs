/*
Let's play the minesweeper game (Wikipedia, online game)! 
You are given a 2D char matrix representing the game board. 'M' represents an unrevealed mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1' to '8') represents how many mines are adjacent to this revealed square, and finally 'X' represents a revealed mine.
Now given the next click position (row and column indices) among all the unrevealed squares ('M' or 'E'), return the board after revealing this position according to the following rules:

If a mine ('M') is revealed, then the game is over - change it to 'X'.
If an empty square ('E') with no adjacent mines is revealed, then change it to revealed blank ('B') and all of its adjacent unrevealed squares should be revealed recursively.
If an empty square ('E') with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
Return the board when no more squares will be revealed.
Example 1:
Input: 

[['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'M', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E']]

Click : [3,0]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:


Example 2:
Input: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Click : [1,2]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'X', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:



Note:
The range of the input matrix's height and width is [1,50].
The click position will only be an unrevealed square ('M' or 'E'), which also means the input board contains at least one clickable square.
The input board won't be a stage when game is over (some mines have been revealed).
For simplicity, not mentioned rules should be ignored in this problem. For example, you don't need to reveal all the unrevealed mines when the game is over, consider any cases that you will win the game or flag any squares.
*/
// Comment: BFS. Neighbors are 8. When visiting neighbors, consider all 8 directions

public class Solution {
    public char[,] UpdateBoard(char[,] board, int[] click) {
        int Row = board.GetLength(0);
        int Col = board.GetLength(1);
        int getData(int i, int j) {
            if (i<0|| i>=Row || j<0||j>=Col)
                return 0; // treat out-of-range as empty\
            char c = board[i,j];
            if (c=='M' || c=='X')
                return -1;
            return 0; // empty either revealed or not
        }
        int getNeighbors(int i, int j)
        {
            if (getData(i,j)==-1)
                return -1;
            int cnt = 0;
            cnt -= getData(i-1,j);
            cnt -= getData(i+1,j);
            cnt -= getData(i,j-1);
            cnt -= getData(i,j+1);
            cnt -= getData(i-1,j-1);
            cnt -= getData(i-1,j+1);
            cnt -= getData(i+1,j-1);
            cnt -= getData(i+1,j+1);
            return cnt;
        }
        
        // Game over when hit the mine
        if (getData(click[0], click[1]) ==-1) {
            board[click[0], click[1]] = 'X';
            return board;
        }
        
        // DFS while exposing distance to mines
        var q = new Queue<int[]>();
        q.Enqueue(click);
        while(q.Count > 0) {
            var n = q.Dequeue();
            int x= n[0];
            int y =n[1];
            if (x<0|| x>=Row || y<0||y>=Col)
                continue;
            char c = board[x,y];
            if (c!='E')
                continue;
            int d = getNeighbors(x, y);
            board[x, y] = d == 0 ? 'B': (char)('0' + d);
            if (d==0) {
                q.Enqueue(new int[2]{x-1, y});
                q.Enqueue(new int[2]{x+1, y});
                q.Enqueue(new int[2]{x, y-1});
                q.Enqueue(new int[2]{x, y+1});
                // Spoiler: visit all 8 directions not just 4 directions
                q.Enqueue(new int[2]{x-1, y-1});
                q.Enqueue(new int[2]{x+1, y-1});
                q.Enqueue(new int[2]{x-1, y+1});
                q.Enqueue(new int[2]{x+1, y+1});                
            }
        }
        
        return board;
    }
}
