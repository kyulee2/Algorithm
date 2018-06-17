/*
Given n points on a 2D plane, find if there is such a line parallel to y-axis that reflect the given points.
Example 1:
Given points = [[1,1],[-1,1]], return true. 
Example 2:
Given points = [[1,1],[-1,-1]], return false. 
Follow up:
Could you do better than O(n2)? 
*/
// Comment: Collect UNIQUE x values for each y. The average value of x is going to be y = a that reflects thoses x.
// Two spoilers
// 1. Points on the axis are allowed.
// 2. Multiple points are allowed.
public class Solution {
    public bool IsReflected(int[,] points) {
        // Spoiler: odd counts/duplication are allowed.
        // E.g, [16,1],[16,1],[-16,1] is true. To handle this need to use HashSet below.
        Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
        int len = points.GetLength(0);
        // Collect y to list of x
        for(int i=0; i<len; i++) {
            int x = points[i,0];
            int y = points[i,1];
            if (!map.ContainsKey(y))
                map[y] = new HashSet<int>();
            map[y].Add(x);
        }
        bool setMed = false;
        double med = 0;
        foreach(var v in map.Values) {
            // Spoiler: Handle odd points.
            // As long as they're on the axis, it's okay
            int sum = 0;
            foreach(var x in v)
                sum += x;
            double m = (double) sum / v.Count;
            if (!setMed) {
                setMed = true;
                med = m;
            }
            else if (Math.Abs(med - m) > 0.000001)
                return false;
            
            // check distance count from med
            Dictionary<double, int> d = new Dictionary<double, int>();
            foreach(var x in v) {                
                double delta = Math.Abs(med - x);
                if (!d.ContainsKey(delta))
                    d[delta] = 1;
                else ++d[delta];
            }
            foreach(var k in d.Keys) {
                if (Math.Abs(k) < 0.000001)
                    continue;
                if (d[k] %2 != 0)
                    return false;
            }
        }
        return true;
    }
}
