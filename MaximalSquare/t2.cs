/*
Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.
Example:
Input: 

1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0

Output: 4
*/
// Comment: Another way like rectangle case instead of DP.
// Use min of width and height to compute the side of square
public class Solution {
    public int MaximalSquare(char[,] matrix) {
        // Use histogram approach like rectangle.
        int Row = matrix.GetLength(0);
        int Col = matrix.GetLength(1);
        var h = new int[Col+1];
        int max = 0;
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++)
                h[j] = (matrix[i,j]=='1') ? h[j] + 1 : 0;
            var s = new Stack<int>();
            for(int j=0; j<=Col; j++) {
                // ascending order
                while(s.Count>0 && h[s.Peek()] > h[j]) {
                    int heigth = h[s.Pop()];
                    int w = s.Count==0 ? j : j - s.Peek() - 1;
                    int side = Math.Min(w,heigth);
                    max = Math.Max(max, side * side);
                }
                s.Push(j);
            }
        }
        return max;
    }
}
