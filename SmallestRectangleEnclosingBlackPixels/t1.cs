/*
An image is represented by a binary matrix with 0 as a white pixel and 1 as a black pixel. The black pixels are connected, i.e., there is only one black region. Pixels are connected horizontally and vertically. Given the location (x, y) of one of the black pixels, return the area of the smallest (axis-aligned) rectangle that encloses all black pixels.

Example:

Input:
[
  "0010",
  "0110",
  "0100"
]
and x = 0, y = 2

Output: 6
*/
// Comment: Simple. No need to reset visited. Otherwise, time-out.

public class Solution {
    int iMin;
    int iMax;
    int jMin;
    int jMax;
    char[,] d;
    int Row;
    int Col;
    bool[,] visited;
    
    void Rec(int i, int j)
    {
        if (i<0||i>=Row||j<0||j>=Col)
            return;
        if (d[i,j]=='0') return;
        if (visited[i,j]) return;
        visited[i,j] = true;
        
        if (i<iMin) iMin = i;
        if (i>iMax) iMax = i;
        if (j<jMin) jMin = j;
        if (j>jMax) jMax = j;
        Rec(i+1, j);
        Rec(i-1, j);
        Rec(i, j+1);
        Rec(i, j-1);
    }
    public int MinArea(char[,] image, int x, int y) {
        d = image;
        Row = d.GetLength(0);
        Col = d.GetLength(1);
        visited = new bool[Row, Col];
        iMin = Row;
        iMax = -1;
        jMin = Col;
        jMax = -1;
        
        Rec(x, y);
        return (jMax-jMin+1) * (iMax-iMin+1);
    }
}

