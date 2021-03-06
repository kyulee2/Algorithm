/*
There is a brick wall in front of you. The wall is rectangular and has several rows of bricks. The bricks have the same height but different width. You want to draw a vertical line from the top to the bottom and cross the least bricks.

The brick wall is represented by a list of rows. Each row is a list of integers representing the width of each brick in this row from left to right.

If your line go through the edge of a brick, then the brick is not considered as crossed. You need to find out how to draw the line to cross the least bricks and return the number of crossed bricks.

You cannot draw a line just along one of the two vertical edges of the wall, in which case the line will obviously cross no bricks.

Example:
Input: 
[[1,2,2,1],
 [3,1,2],
 [1,3,2],
 [2,4],
 [3,1,2],
 [1,3,1,1]]
Output: 2
Explanation: 

Note:
The width sum of bricks in different rows are the same and won't exceed INT_MAX.
The number of bricks in each row is in range [1,10,000]. The height of wall is in range [1,10,000]. Total number of bricks of the wall won't exceed 20,000.
*/
// Comment: Simple max problem that has  the largest count at  sum of width for each row
// The answer should be min by reverseing the max found above
// Don't add up the last width which is the last edge.
public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        var map = new Dictionary<int, int>(); //sum, cnt
        int max = 0;
        int len = wall.Count;
        foreach(var ws in wall) {
            int s = 0;
            for(int i=0; i<ws.Count-1; i++) {
                s += ws[i];
                if (!map.ContainsKey(s)) {
                    map[s] = 1;
                } else {
                    map[s]++;
                }
                max = Math.Max(max, map[s]);
            }
        }
        
        return len - max;
    }
} 
