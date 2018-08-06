/*
Given n points in the plane that are all pairwise distinct, a "boomerang" is a tuple of points (i, j, k) such that the distance between i and j equals the distance between i and k (the order of the tuple matters).

Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of points are all in the range [-10000, 10000] (inclusive).

Example:
Input:
[[0,0],[1,0],[2,0]]

Output:
2

Explanation:
The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
*/
// Comment: For each point, count all distances with other points using a map.
// Sum up the combinations of the same distance. n*(n-1). E.g, if there are two same distances, there are 2 = 2 * (2-1) boomerangs.
public class Solution {
    public int NumberOfBoomerangs(int[,] points) {
        int len = points.GetLength(0);
        int ans = 0;
        for(int i=0; i<len; i++) {
            var map = new Dictionary<int, int>();
            for(int j=0; j<len; j++) {
                if (i==j) continue;
                int dx = points[i,0] - points[j,0];
                int dy = points[i,1] - points[j,1];
                int d2 = dx * dx + dy * dy;
                if  (!map.ContainsKey(d2))
                    map[d2] = 1;
                else ++map[d2];
            }
            foreach(var v in map.Values) {
                ans += v * (v-1);
            }
        }
        
        return ans;
    }
}
