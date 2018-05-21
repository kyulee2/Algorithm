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

// Comment: Given evenly distributed calls to upate/sumRegion, we should not bias one operation over the other for complexity. The key idea is column sum or row sum table. The latter is slightly better in terms of cache access.
// t2.cs/t3.cs is another approach which is biased to a certain case like O(1) for sumRegion, etc.
// The following passes all cases. O(n) update and O(m) sumRegion for the worst case.

public class NumMatrix {
    int Row;
    int Col;
    int[,] mat;
    int[,] sum; // rowsum
    
    int getSum(int row, int col){
        if (row<0 || row>= Row) return 0;
        if (col<0 || col>= Col) return 0;
        return sum[row, col];
    }
    
    public NumMatrix(int[,] matrix) {
        Row = matrix.GetLength(0);
        Col = matrix.GetLength(1);
        mat = matrix;
        sum = new int[Row, Col];
        for(int j = 0; j < Col; j++)
            Update(0, j, mat[0, j]);
    }
    
    // worst O(n)
    public void Update(int row, int col, int val) {
        mat[row, col] = val;
        for(int i=row; i < Row; i++) {
            sum[i, col] = mat[i, col] + getSum(i-1, col);
        }
    }
    
    // worst O(m)
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int s = 0;
        for(int j = col1; j <= col2; j++) {
            s += getSum(row2, j) - getSum(row1-1, j);
        }
        return s;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * obj.Update(row,col,val);
 * int param_2 = obj.SumRegion(row1,col1,row2,col2);
 */

