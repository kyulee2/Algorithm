/*
You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water. Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells). The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
Example: 
[[0,1,0,0],
 [1,1,1,0],
 [0,1,0,0],
 [1,1,0,0]]

Answer: 16
Explanation: The perimeter is the 16 yellow stripes in the image below:

*/

public class Solution {
    int[,] g;
    int Row;
    int Col;
    int getVal(int i, int j)
    {
        if (i<0 || i>=Row || j<0 || j>=Col)
            return 0;
        return g[i,j];
    }
        
    int getPerm(int i, int j)
    {
        if (getVal(i,j) == 0) return 0;
        return 4 - getVal(i-1,j) - getVal(i,j-1) - getVal(i+1,j) - getVal(i,j+1);  
    }
    
    public int IslandPerimeter(int[,] grid) {
        g = grid;
        Row = g.GetLength(0);
        Col = g.GetLength(1);
        int p = 0;
        for(int i=0; i<Row;i++)
            for(int j=0; j<Col;j++)
                p+= getPerm(i,j);
        return p;
    }
}
