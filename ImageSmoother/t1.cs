/*
Given a 2D integer matrix M representing the gray scale of an image, you need to design a smoother to make the gray scale of each cell becomes the average gray scale (rounding down) of all the 8 surrounding cells and itself. If a cell has less than 8 surrounding cells, then use as many as you can.
Example 1:
Input:
[[1,1,1],
 [1,0,1],
 [1,1,1]]
Output:
[[0, 0, 0],
 [0, 0, 0],
 [0, 0, 0]]
Explanation:
For the point (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the point (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0

Note:
The value in the given matrix is in the range of [0, 255].
The length and width of the given matrix are in the range of [1, 150].
*/
// Comment: Similar to Game of Life.
class Solution {
    public int[,] ImageSmoother(int[,] M) {
        int Row = M.GetLength(0);
        int Col = M.GetLength(1);
        var Out = new int[Col];
        var Prev = new int[Col];
        int update(int i, int j) {
            int cnt = 1, sum = M[i,j];
            // Previous row
            if (i-1>=0) {
                if (j-1>=0) {
                    sum += Prev[j-1];
                    cnt++;
                }
                sum += Prev[j];
                cnt++;
                if (j+1<Col) {
                    sum += Prev[j+1];
                    cnt++;
                }
            }
            // Current row
            if (j-1>=0) {
                sum+= M[i,j-1];
                cnt++;
            }
            if (j+1<Col) {
                sum+= M[i,j+1];
                cnt++;
            }
            // Next row
            if (i+1< Row) {
                if (j-1>=0) {
                    sum += M[i+1, j-1];
                    cnt++;
                }
                sum += M[i+1, j];
                cnt++;
                if (j+1<Col) {
                    sum += M[i+1, j+1];
                    cnt++;
                }    
            }
            return sum/cnt;
        }
        
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++)
                Out[j] = update(i,j);
            for(int j=0; j<Col; j++) {
                Prev[j] = M[i,j];
                M[i,j] = Out[j];
            }
        }
        return M;
    }
}
