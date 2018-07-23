/*

Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Example:

Input:
[
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
Output: 6

*/
// Comment: Quite interesting. use historgram apporach.
public class Solution {
    public int MaximalRectangle(char[,] matrix) {
        int Row = matrix.GetLength(0);
        int Col = matrix.GetLength(1);
        var h = new int[Col+1];
        int max = 0;
        for(int i=0; i<Row; i++) {
            for(int j=0; j<Col; j++)
                h[j] = (matrix[i,j]=='1') ? h[j] + 1 : 0;
            var s = new Stack<int>();
            for(int j=0; j<=Col; j++) {                
                while(s.Count>0 && h[s.Peek()] > h[j]) {
                    int height = h[s.Pop()];
                    // Spoiler: The width starts from the prior value in stack - 1
                    // Think about 1 3 2 2 above. When 3 is removed, 1 X 2 2 remains.
                    // The rectangle width starts after 1                    
                    int w = s.Count == 0 ? j : j - s.Peek() - 1;
                    max = Math.Max(max, w * height);
                }
                s.Push(j);
            }
        }
        return max;
    }
}
