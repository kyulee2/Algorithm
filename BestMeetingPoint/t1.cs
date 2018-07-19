/*
A group of two or more people wants to meet and minimize the total travel distance. You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.
Example:
Input: 

1 - 0 - 0 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0

Output: 6 

Explanation: Given three people living at (0,0), (0,4), and (2,2):
             The point (0,2) is an ideal meeting point, as the total travel distance 
             of 2+2+2=6 is minimal. So return 6.
*/
// Comment: Similar to Shortest Distance from All buildings, but totally different approach.
// Not blocking, and it's alllowed to meet at people's position.
// Basically it's getting sum of distance from the median value from the sorted array.
public class Solution
{
    public int MinTotalDistance(int[,] grid)
    {
        int Row = grid.GetLength(0);
        int Col = grid.GetLength(1);

        var listi = new List<int>();
        var listj = new List<int>();
        for (int i = 0; i < Row; i++)
            for (int j = 0; j < Col; j++)
                if (grid[i, j] == 1)
                {
                    listi.Add(i);
                    listj.Add(j);
                }

        int getDist(List<int> list)
        {
            list.Sort();
            
            int x = 0, y = list.Count - 1;
            int dist = 0;
            while (x < y)
                dist += list[y--] - list[x++];
            
            return dist;
        }

        return getDist(listi) + getDist(listj);
    }
}

