/*
Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image. 
Example:
Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
Output:  [1,2,4,7,5,3,6,8,9]
Explanation:


Note:
The total number of elements of the given matrix will not exceed 10,000.
*/
// Comment: Make an iter (m+n-1) position by alternating odd/even.
// From there, either up/right or down/left.
public class Solution {
    int Row;
    int Col;
    int[,] m;
    int[,] iter;
    int[] ans;
    public int[] FindDiagonalOrder(int[,] matrix) {
        // Spoiler: empty matrix
        if (matrix.Length == 0) return new int[0];
        
        m = matrix;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        int cnt = Row + Col - 1;
        iter = new int[cnt, 2];
        ans = new int[Row * Col];
        // Build iter

        // Even
        int k = 0;
        for(int j=0; j<Col; j++,k++) {
            if (k%2 !=1) continue;
            iter[k,0] = 0;
            iter[k,1] = j;            
        }
        for(int i=1; i<Row; i++, k++) {
            if (k%2 !=1) continue;            
            iter[k,0] = i;
            iter[k,1] = Col-1;            
        }
        
        // Odd
        k = 0;
        for(int i=0; i<Row; i++, k++) {
            if (k%2 !=0) continue;            
            iter[k,0] = i;
            iter[k,1] = 0;            
        }
        for(int j=1; j<Col; j++,k++) {
            if (k%2 !=0) continue;
            iter[k,0] = Row-1;
            iter[k,1] = j;            
        }
        
        int idx = 0;
        for(k=0; k<cnt; k++) {
            int i = iter[k,0];
            int j = iter[k,1];
            while(i>=0 && i<Row && j>=0 && j<Col) {
                ans[idx++] = m[i,j];
                if (k%2 == 0) {// right up
                    i--; j++;
                }
                else  { // left down
                    i++; j--;
                }                
            }        
        }
        
        return ans;
    }
}
