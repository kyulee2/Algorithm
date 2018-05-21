// Comment: Slightly better than t2.cs
// Lazy update for getSum(). Upate O(1) while SumRegion O(n^2) for the first access.
// Stil fails due to time limit
public class NumMatrix {
    int Row;
    int Col;
    int[,] mat;
    int[,] sum;
    
    bool needUpdate;
    int minRow;
    int minCol;
    
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
        needUpdate = true;        
    }
    
    public void Update(int row, int col, int val) {
        mat[row, col] = val;
        needUpdate = true;
        if (row<minRow) minRow = row;
        if (col<minCol) minCol = col;       
    }
    
    void checkUpdate()
    {
        if(!needUpdate) return;
        for(int i=minRow; i<Row; i++)
            for(int j=minCol; j<Col; j++)
                updateSum(i,j);
        minRow = Row;
        minCol = Col;
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        checkUpdate();
        
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
