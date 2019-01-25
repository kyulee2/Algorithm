/*
Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
Example 1:
Input: 
[
  [1,1,1],
  [1,0,1],
  [1,1,1]
]
Output: 
[
  [1,0,1],
  [0,0,0],
  [1,0,1]
]
Example 2:
Input: 
[
  [0,1,2,0],
  [3,4,5,2],
  [1,3,1,5]
]
Output: 
[
  [0,0,0,0],
  [0,4,5,0],
  [0,3,1,0]
]
Follow up:
A straight forward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?
*/
// Comment: Mark 0 summary on each 0 row or 0 col. Handle (0,0) specially.
class Solution {
public:
    void setZeroes(vector<vector<int>>& matrix) {
        int Row = matrix.size();
        if (Row==0) return;
        int Col = matrix[0].size();
        bool zeroRow = false, zeroCol = false;
        if (matrix[0][0]==0) {zeroRow = true; zeroCol = true;}
        
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                if (i==0 && j==0) continue;
                if (matrix[i][j]==0) {
                    if (i==0) zeroRow = true;
                    if (j==0) zeroCol = true;
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        
        for(int i=1; i<Row; i++)
            if (matrix[i][0]==0)
                for(int j=0; j<Col; j++)
                    matrix[i][j] = 0;
        for(int j=1; j<Col; j++)
            if (matrix[0][j]==0)
                for(int i=0; i<Row; i++)
                    matrix[i][j] = 0;
        
        if (zeroRow)
            for(int j=0; j<Col; j++)
                matrix[0][j] = 0;
        if (zeroCol)
            for(int i=0; i<Row; i++)
                matrix[i][0] = 0;
    }
};