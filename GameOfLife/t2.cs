/*
According to the Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970." 
Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article): 

Any live cell with fewer than two live neighbors dies, as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population..
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

Write a function to compute the next state (after one update) of the board given its current state.
Follow up: 
Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
In this question, we represent the board using a 2D array. In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array. How would you address these problems?
*/

// Comment: The below solves it in-place with two additional 1D (column) array.
// If we consider the follow-up second item above, we could assume circular mapping -- the left of the first maps the right of the last entry, etc. If that is the case, we need additional thrid array for the last iteration.
// The test case does not assume this, instead all out-of-boundary index are treated as dead (0).

public class Solution {
    public void GameOfLife(int[][] board) {
        int Row = board.Length;
        if (Row==0)
            return;
        int Col = board[0].Length;
        var Out = new int[Col];
        var Prev = new int[Col];
        
        // Get live neighbors
        int getLiveNeighbors(int i, int j)
        {
            int n = 0;
            if (i-1>=0) {
                if (j-1>=0) n+= Prev[j-1];
                n += Prev[j];
                if (j+1<Col) n+= Prev[j+1];
            }
            if (j-1>=0) n+= board[i][j-1];
            if (j+1<Col) n+= board[i][j+1];
            if (i+1<Row) {
                if (j-1>=0) n+= board[i+1][j-1];
                n+=board[i+1][j];
                if (j+1<Col) n+= board[i+1][j+1];
            }
            return n;
        }
        
        // Get next stats for the given live count
        int update(int live, int n)
        {
            if (live == 1) {
                if (n<2) return 0;
                if (n==2 || n==3) return 1;
                if (n>3) return 0;
            } else {
                if (n==3)
                    return 1;
            }
            return live;
        }
        
        // main loop
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++)
                Out[j] = update(board[i][j], getLiveNeighbors(i,j));
            for(int j=0; j<Col; j++) {
                Prev[j] = board[i][j];
                board[i][j] = Out[j];
            }
        }
    }
}
