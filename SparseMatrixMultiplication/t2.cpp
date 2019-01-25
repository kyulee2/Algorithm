/*
Given two sparse matrices A and B, return the result of AB.

You may assume that A's column number is equal to B's row number.

Example:

Input:

A = [
  [ 1, 0, 0],
  [-1, 0, 3]
]

B = [
  [ 7, 0, 0 ],
  [ 0, 0, 0 ],
  [ 0, 0, 1 ]
]

Output:

     |  1 0 0 |   | 7 0 0 |   |  7 0 0 |
AB = | -1 0 3 | x | 0 0 0 | = | -7 0 3 |
                  | 0 0 1 |
*/
// Comment: Another approach than t1.cs
// Use map to capture summary of row for A and col for B respectively.
// For the inner loop with k, do computation only when element in the map corresponding to [i,k] or [k,j] exists.
class Solution {
public:
    vector<vector<int>> multiply(vector<vector<int>>& A, vector<vector<int>>& B) {
        int Row1 = A.size();
        if (Row1==0) return vector<vector<int>>();
        int Col1 = A[0].size();
        int Row2 = B.size();
        if (Row2==0) return vector<vector<int>>();
        int Col2 = B[0].size();
        map<int, map<int, int>> m1; // summary for row of A, row1:col1 -> val
        map<int, map<int, int>> m2; // summary for col of B, col2::row2 ->val
        for(int i=0; i<Row1; i++)
            for(int j=0; j<Col1; j++) {
                int val =A[i][j];
                if (val==0) continue;
                m1[i][j] = val;
            }
        for(int i=0; i<Row2; i++)
            for(int j=0; j<Col2; j++) {
                int val =B[i][j];
                if (val==0) continue;
                m2[j][i] = val;
            }     
        
        vector<vector<int>> ans(Row1, vector<int>(Col2, 0));
        for(int i=0; i<Row1; i++)
            for(int j=0; j<Col2; j++) {
                if (m1.find(i)==m1.end() || m2.find(j)==m2.end())
                    continue;
                int t = 0;
                auto& rows = m1[i];
                auto& cols = m2[j];
                for(int k=0; k<Col1; k++) { // assert Col1 == Row2
                    if (rows.find(k)==rows.end() || cols.find(k)==cols.end())
                        continue;
                    t += rows[k] * cols[k];
                }
                ans[i][j] = t;
            }
        
        return ans;
    }
};
