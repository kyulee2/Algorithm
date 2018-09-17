/*
N cars are going to the same destination along a one lane road.  The destination is target miles away.

Each car i has a constant speed speed[i] (in miles per hour), and initial position position[i] miles towards the target along the road.

A car can never pass another car ahead of it, but it can catch up to it, and drive bumper to bumper at the same speed.

The distance between these two cars is ignored - they are assumed to have the same position.

A car fleet is some non-empty set of cars driving at the same position and same speed.  Note that a single car is also a car fleet.

If a car catches up to a car fleet right at the destination point, it will still be considered as one car fleet.


How many car fleets will arrive at the destination?

 

Example 1:

Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
Output: 3
Explanation:
The cars starting at 10 and 8 become a fleet, meeting each other at 12.
The car starting at 0 doesn't catch up to any other car, so it is a fleet by itself.
The cars starting at 5 and 3 become a fleet, meeting each other at 6.
Note that no other cars meet these fleets before the destination, so the answer is 3.

Note:

0 <= N <= 10 ^ 4
0 < target <= 10 ^ 6
0 < speed[i] <= 10 ^ 6
0 <= position[i] < target
All initial positions are different.
*/
// Comment: Sort by position in a decreasing order.
// Compute time for ahead car to arrive vs. time for current car to catch the prior fleet.
// Since slowest car (ahead) governs arrival time, when merging fleet, we only need to record the last(prior/ahead) car only.
public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        int len = speed.Length;
        if (len==0)
            return 0;
        var l = new List<int[]>();
        for(int i=0; i<len; i++)
            l.Add(new int[2]{position[i], speed[i]});
        l.Sort((x,y)=>y[0]-x[0]); // decreasing order
        
        // Init the last(10) car to the fleet itself
        var map = new Dictionary<int, int[]>(); // pos to [pos, speed]
        map[l[0][0]] = l[0];
        
        for(int i=1; i<len; i++) {
            var prev = map[l[i-1][0]];
            var curr = l[i];
            if (prev[0] == curr[0]) // same starting position
                continue;
            if (prev[1] >= curr[1]) {// current is slower. no interest
                map[curr[0]] = curr;
                continue;
            }
            // catch up time
            double t1 = ((double)prev[0] - curr[0]) / (double)(curr[1]-prev[1]);
            // time for prev to arrive
            double t2 = ((double)target -prev[0]) / (double)prev[1];
            //Console.WriteLine("{0} {1}", t1, t2);
            if (t1 <= t2) {
                // merge fleet -- just points to previous feet
                map[curr[0]] = prev;
            } else {
                map[curr[0]] = curr;
            }
        }
        
        var tans = new HashSet<int[]>();
        foreach(var v in map.Values)
            tans.Add(v);
        return tans.Count;
    }
}
