/*
Given an 2D board, count how many battleships are in it. The battleships are represented with 'X's, empty slots are represented with '.'s. You may assume the following rules: 
You receive a valid board, made of only battleships or empty slots.
Battleships can only be placed horizontally or vertically. In other words, they can only be made of the shape 1xN (1 row, N columns) or Nx1 (N rows, 1 column), where N can be of any size.
At least one horizontal or vertical cell separates between two battleships - there are no adjacent battleships.
Example:
X..X
...X
...X
In the above board there are 2 battleships. 
Invalid Example:
...X
XXXX
...X
This is an invalid board that you will not receive - as battleships will always have a cell separating between them. 

Follow up:
Could you do it in one-pass, using only O(1) extra memory and without modifying the value of the board?
*/
// Comment: The key point is to check prior col and prior row to see if it's contiguous.
public class Solution {
    public int CountBattleships(char[,] board) {
        int Row = board.GetLength(0);
        int Col = board.GetLength(1);
        char getData(int i, int j) {
            if (i<0 || i>=Row || j<0 || j>=Col)
                return '.';
            return board[i,j];
        }
        
        int sum = 0;
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (getData(i,j) == 'X') {
                    if (getData(i-1, j) == '.' && getData(i,j-1) =='.')
                        sum++;
                }
        
        return sum;
    }
}
