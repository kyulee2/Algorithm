/*
Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

Count the number of distinct islands. An island is considered to be the same as another if and only if one island can be translated (and not rotated or reflected) to equal the other.

Example 1:
11000
11000
00011
00011
Given the above grid map, return 1.
Example 2:
11011
10000
00001
11011
Given the above grid map, return 3.

Notice that:
11
1
and
 1
11
are considered different island shapes, because we do not consider reflection / rotation.
Note: The length of each dimension in the given grid does not exceed 50.
*/
// Comment: Interesting about how to match the same shape. HashSet<HashSet<int>> does not work in c#.
// Instead, record each direction of recursive calls. But note that we should add signature at each level as 0 as well to create unique sequence.
// O(mn) time and space.
public class Solution {
    public int NumDistinctIslands(int[,] grid) {
        /// use path signature
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);
        void Rec(int i, int j, int d, StringBuilder t)
        {
            if (i<0|| j<0|| i>=Row || j>=Col || grid[i,j]!=1)
                return;
            t.Append(d);
            grid[i,j] = 2;
            Rec(i+1, j, 1, t);
            Rec(i-1, j, 2, t);
            Rec(i, j+1, 3, t);
            Rec(i, j-1, 4, t);
            t.Append(0); // Spoiler: add signature for the current level
        }
        var anst = new HashSet<string>();
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++)
                if (grid[i,j] == 1) {
                    var sig = new StringBuilder();
                    Rec(i,j, 0, sig);
                    anst.Add(sig.ToString());
                }
        
        return anst.Count;
    }
}
