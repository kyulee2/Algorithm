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
    int Row;
    int Col;
    int[,] b;
    int[] Prev;
    int[] Out;
    int[] Last;

    int getLiveNeighbor(int i, int j)
    {
        int live = 0;
        // Previous row
        live += (j == 0 ? 0 : Prev[j-1]) + Prev[j] + (j==Col-1 ? 0: Prev[j+1]);
        // Current row
        live += (j == 0 ? 0 : b[i, j-1]) + (j==Col-1 ? 0 :b[i, j+1]);
        // Next row
        live += (i==Row-1 ? 0 :( (j==0? 0: b[i+1, j-1]) + b[i+1, j] + (j==Col-1? 0 :b[i+1, j+1])));
        return live;
    }
                         
    int update(int i, int j, int n)
    {
        int curr = b[i,j];
        if (curr == 0) {
            if (n==3) return 1;
        } else {
            if (n<2) return 0;
            else if (n==2 || n ==3) return 1;
            else /* n>3 */ return 0;
        }
        return 0;
    }
                             
                         
    public void GameOfLife(int[,] board) {
        // Allocate
        b = board;
        Row = b.GetLength(0);
        Col = b.GetLength(1);
         Prev = new int[Col];
        Out = new int[Col];
     
        // Main loop
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++) {
                Out[j] = update(i, j, getLiveNeighbor(i,j));
            }
            // Copy Curr to Prev and Flush Out to b in place
            for(int j=0; j<Col; j++) {
                Prev[j] = b[i,j];
                b[i,j] = Out[j];
            }
        }               
            
    }
}

