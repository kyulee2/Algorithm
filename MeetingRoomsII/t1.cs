/*
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.
Example 1:
Input: [[0, 30],[5, 10],[15, 20]]
Output: 2
Example 2:
Input: [[7,10],[2,4]]
Output: 1
*/

// Comment: Basically, it is a problem of finding the number of conflicts + 1 for the given live range.
// The idea is to sort time regardless of start/end into a set while maintaining two maps for start/end count.
// For each time, either decrease rooms from the end map or increase rooms from the start map.
// 1. HashSet -> Array api. Create [] and the CopyTo
// TODO: There may be a better (less space) algorithm than this..
//
/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public int MinMeetingRooms(Interval[] intervals) {
        // Build two maps - start : cnt, end :cnd
        int Len = intervals.Length;
        if (Len == 0) return 0;
        Dictionary<int, int> smap = new Dictionary<int, int>();
        Dictionary<int, int> emap = new Dictionary<int, int>();
        HashSet<int> timeset = new HashSet<int>();
        foreach(var I in intervals) {
            int start = I.start;
            int end = I.end;
            timeset.Add(start);
            timeset.Add(end);
            if (!smap.ContainsKey(start)) smap[start] = 1;
            else ++smap[start];
            if (!emap.ContainsKey(end)) emap[end] = 1;
            else ++emap[end];
        }

        // Sort by time regardless of start/end - int[]
        int[] time = new int[timeset.Count];
        timeset.CopyTo(time);
        Array.Sort(time);

        // Track room count (for end -, for start + from the map)
        // Keep track of max of the room/conflict count
        int room = 0;
        int max = 0;
        foreach(var t in time) {
            if (emap.ContainsKey(t))
                room -= emap[t];
            if (smap.ContainsKey(t))
                room += smap[t];
            if (room > max)
                max = room;
        }
        return max;
    }
}

