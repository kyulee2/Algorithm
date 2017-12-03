/*
Medium: Rotate Image

You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise) in place.
*/
public class Solution {
    public void Rotate(int[,] matrix) {
        // Length for entire elements count
        // GetLength(dim): array element count for each dimension
        int n = matrix.GetLength(0);
        Rec(matrix, 0, n-1);
    }
    public void Rec(int[,] matrix, int s, int e)
    {
        if (s >= e)
            return;
        for (int i = s ; i < e ; i++)
        {
            // top -> right
            int right = matrix[i,e];
            matrix[i,e] = matrix[s,i];
            // right -> bottom
            int bottom = matrix[e,e-(i-s)];
            matrix[e,e-(i-s)] = right;
            // bottom -> left
            int left = matrix[e-(i-s),s];
            matrix[e-(i-s),s] = bottom;
            // left -> top
            matrix[s,i] = left;
        }
        Rec(matrix, s+1, e-1);
    }
}

