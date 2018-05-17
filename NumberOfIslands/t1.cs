/*
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:

Input:
11110
11010
11000
00000

Output: 1
Example 2:

Input:
11000
11000
00100
00011

Output: 3
*/

// Comment
// 1. GetLength() to get array size
// 2. char[,] requires char '' (neither string "" nor integer)
public class Solution
{
    public int NumIslands(char[,] grid)
    {
        Map = grid;
        XLen = grid.GetLength(0);
        YLen = grid.GetLength(1);
        int Count = 0;
        for (int i = 0; i < XLen; i++)
        {
            for (int j = 0; j < YLen; j++)
            {
                if (Map[i, j] == '1')
                {
                    Count++;
                    Recurse(i, j);
                }
            }
        }
        Restore();
        return Count;
    }

    void Restore()
    {
        for (int i = 0; i < XLen; i++)
            for (int j = 0; j < YLen; j++)
                if (Map[i, j] == '2')
                    Map[i, j] = '1';
    }

    void Recurse(int i, int j)
    {
        if (i < 0 || i >= XLen) return;
        if (j < 0 || j >= YLen) return;
        if (Map[i, j] != '1') return;
        Map[i, j] = '2';
        Recurse(i + 1, j);
        Recurse(i - 1, j);
        Recurse(i, j + 1);
        Recurse(i, j - 1);
    }

    int XLen;
    int YLen;
    char[,] Map;
}

