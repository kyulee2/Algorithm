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
// Comment: Loop interchange -- see loop k, j are reversed.
// Net effect is to add solution to column order. This way we can avoid unnecessary computation.
public class Solution {
    public int[,] Multiply(int[,] A, int[,] B) {
        // n x m * m * l
        int n = A.GetLength(0);
        int m = A.GetLength(1);
        int l = B.GetLength(1);
        var C = new int[n,l];
        
        for(int i=0; i<n; i++)
            for(int k=0; k<m; k++)
                if (A[i,k] !=0) {
                    for(int j=0; j<l; j++)
                        if (B[k,j]!=0)
                            C[i,j] += A[i,k]*B[k,j];
                }
        
        return C;
    }
}
