/*
Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
Consider the following matrix:
[
  [1,   4,  7, 11, 15],
  [2,   5,  8, 12, 19],
  [3,   6,  9, 16, 22],
  [10, 13, 14, 17, 24],
  [18, 21, 23, 26, 30]
]
Example 1:
Input: matrix, target = 5
Output: true
Example 2:
Input: matrix, target = 20
Output: false
*/

// Comment: O(sqrt(m^2 + n^2))?
// Start from the corner of right/top. If r is smaller, go down (row+1), 
// if r is bigger than key, go left (col -1)
public class Solution {
    int[,] m;
    int Row;
    int Col;
    int key;
    
    public bool SearchMatrix(int[,] matrix, int target) {
        key = target;
        m = matrix;
        Row = m.GetLength(0);
        Col = m.GetLength(1);
        return Rec(0, Col - 1);        
    }

    bool isValid(int i, int j)
    {
        return i >= 0 && i < Row && j >= 0 && j < Col;
    }

    bool Rec(int i, int j)
    {
        if (!isValid(i, j)) return false;
        int r = m[i, j];
        if (key == r) return true;
        if (r > key)
            return Rec(i, j - 1);
        else // r < key
            return Rec(i + 1, j);
    }    
}
