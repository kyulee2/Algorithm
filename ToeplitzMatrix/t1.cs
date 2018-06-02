/*
A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.
Now given an M x N matrix, return True if and only if the matrix is Toeplitz.
 
Example 1:
Input: matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]
Output: True
Explanation:
1234
5123
9512

In the above grid, the diagonals are "[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]", and in each diagonal all elements are the same, so the answer is True.
Example 2:
Input: matrix = [[1,2],[2,2]]
Output: False
Explanation:
The diagonal "[1, 2]" has different elements.
Note:
matrix will be a 2D array of integers.
matrix will have a number of rows and columns in range [1, 20].
matrix[i][j] will be integers in range [0, 99].
*/

// Comment: Just be careful for the first col iteration where row starts from 1 not 0.
// Other than that, it's same as first row case.

public class Solution {
    
    bool Rec(int i, int j, int t)
    {
        if (i>=Row || j>=Col)
            return true;
        if (m[i,j] != t)
            return false;
        return Rec(i+1, j+1, t);
    }
    
    int[,] m;
    int Row;
    int Col;
    public bool IsToeplitzMatrix(int[,] matrix) {
        // Initialize
        m = matrix;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        if (Row==0 || Col==0)
            return true;
        
        // Main loop - top row and first col respectively.
        for(int j=0; j<Col; j++)
            if (!Rec(1,j+1, m[0,j]))
                return false;
        for(int i=1; i<Row; i++)
            if (!Rec(i+1,1, m[i,0]))
                return false;
        
        return true;
    }
}
