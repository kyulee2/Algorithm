/*
This question is about implementing a basic elimination algorithm for Candy Crush.

Given a 2D integer array board representing the grid of candy, different positive integers board[i][j] represent different types of candies. A value of board[i][j] = 0 represents that the cell at position (i, j) is empty. The given board represents the state of the game following the player's move. Now, you need to restore the board to a stable state by crushing candies according to the following rules:

If three or more candies of the same type are adjacent vertically or horizontally, "crush" them all at the same time - these positions become empty.
After crushing all candies simultaneously, if an empty space on the board has candies on top of itself, then these candies will drop until they hit a candy or bottom at the same time. (No new candies will drop outside the top boundary.)
After the above steps, there may exist more candies that can be crushed. If so, you need to repeat the above steps.
If there does not exist more candies that can be crushed (ie. the board is stable), then return the current board.
You need to perform the above rules until the board becomes stable, then return the current board.

 

Example:

Input: board =  [[110,5,112,113,114],[210,211,5,213,214],[310,311,3,313,314],[410,411,412,5,414],[5,1,512,3,3],[610,4,1,613,614],[710,1,2,713,714],[810,1,2,1,1],[1,1,2,2,2],[4,1,4,4,1014]]  Output: [[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[110,0,0,0,114],[210,0,0,0,214],[310,0,0,113,314],[410,0,0,213,414],[610,211,112,313,614],[710,311,412,613,714],[810,411,512,713,1014]]  Explanation:   
 

Note:

The length of board will be in the range [3, 50].
The length of board[i] will be in the range [3, 50].
Each board[i][j] will initially start as an integer in the range [1, 2000].
*/
// Comment: Interesting. Mark crushed candies with set or list.
// Drop/move each col using two pointers.
// Recursively do this until no crushed candies
public class Solution {
    int Row, Col;
    public int[,] CandyCrush(int[,] board) {
        Row = board.GetLength(0);
        Col = board.GetLength(1);
        //bool needDrop = false;
        var s = new List<int[]>();
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (board[i,j]==0) continue;
                else if ((i<Row-2 && board[i,j]==board[i+1,j] && board[i,j]==board[i+2,j]) ||
                    (i>0&&i<Row-1 && board[i-1,j]==board[i,j] && board[i,j]==board[i+1,j]) ||
                    (i>1&&board[i-2,j]==board[i,j] && board[i-1,j]==board[i,j]) ||
                    (j<Col-2 && board[i,j]==board[i,j+1] && board[i,j]==board[i,j+2]) ||
                    (j>0&&j<Col-1&& board[i,j-1]==board[i,j] && board[i,j]==board[i,j+1]) ||
                    (j>1&&board[i,j-2]==board[i,j]&&board[i,j-1]==board[i,j]))
                    s.Add(new int[]{i,j});
        foreach(var n in s)
            board[n[0],n[1]] = 0;
        if (s.Count ==0)
            return board;
        drop(board);
        return CandyCrush(board);
    }
    
    void drop(int[,] board) {
        // use two pointers
        for(int j=0; j<Col; j++) {
            int top = Row-1;
            int bot = Row - 1;
            while(top>=0) {
                if (board[top,j] ==0)
                    top--;
                else board[bot--, j] = board[top--, j];
            }
            while(bot>=0)
                board[bot--, j] = 0;
        }
    }
}
