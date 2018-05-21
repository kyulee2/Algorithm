/*
Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

The above rectangle (with the red border) is defined by (row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8. 
Example:
Given matrix = [
  [3, 0, 1, 4, 2],
  [5, 6, 3, 2, 1],
  [1, 2, 0, 1, 5],
  [4, 1, 0, 1, 7],
  [1, 0, 3, 0, 5]
]

sumRegion(2, 1, 4, 3) -> 8
update(3, 2, 2)
sumRegion(2, 1, 4, 3) -> 10

Note:
The matrix is only modifiable by the update function.
You may assume the number of calls to update and sumRegion function is distributed evenly.
You may assume that row1 <= row2 and col1 <= col2

*/
// COMMENT: The below code works functionally (16/17) but fails due to time-limit for large input.
// Update function is O(n^2)...
public class NumMatrix {
    int Row;
    int Col;
    int[,] mat;
    int[,] sum;
    
    int getSum(int row, int col){
        if (row<0 || row>= Row) return 0;
        if (col<0 || col>= Col) return 0;
        return sum[row, col];
    }
    
    void updateSum(int row, int col) {
        sum[row, col] = getSum(row-1, col) + getSum(row, col-1) + mat[row, col] - getSum(row-1, col-1);
    }
    
    public NumMatrix(int[,] matrix) {
        Row = matrix.GetLength(0);
        Col = matrix.GetLength(1);
        mat = matrix;
        sum = new int[Row, Col];
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                updateSum(i,j);
    }
    
    public void Update(int row, int col, int val) {
        mat[row, col] = val;
        for(int i=row; i < Row; i++)
            for(int j=col; j < Col; j++)
                updateSum(i, j);
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        // S = S4 - S3 - S2 + S1
        int S4 = getSum(row2, col2);
        int S3 = getSum(row1-1, col2);
        int S2 = getSum(row2, col1-1);
        int S1 = getSum(row1-1, col1 -1);
        return S4 - S3 - S2 + S1;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */
