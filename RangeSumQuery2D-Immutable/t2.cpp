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
sumRegion(1, 1, 2, 2) -> 11
sumRegion(1, 2, 2, 4) -> 12

Note:
You may assume that the matrix does not change.
There are many calls to sumRegion function.
You may assume that row1 <= row2 and col1 <= col2
*/
// Comment: Think about prefix sum for 2D
class NumMatrix {
public:
    vector<vector<int>> S;
    int row, col;
    NumMatrix(vector<vector<int>> matrix) {
        row = matrix.size();
        if (row==0) return;
        col = matrix[0].size();
        S.resize(row, vector<int>(col, 0));
        
        for(int i =0; i<row; i++) {
            int rs = 0;
            for(int j=0; j<col; j++) {
                rs = rs + matrix[i][j];
                S[i][j] += rs + sum(i-1, j);
            }
        }
    }
    
    int sum(int r, int c) {
        if (r<0 || c<0 || r>=row || c>=col)
            return 0;
        return S[r][c];
    }
    int sumRegion(int row1, int col1, int row2, int col2) {
        if (S.size()==0) return 0;
        int s = 0;
        s = sum(row2, col2) + sum(row1-1, col1-1);
        s = s - sum(row2, col1-1) - sum(row1-1, col2);
        return s;
    }
};

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.sumRegion(row1,col1,row2,col2);
 */