/*
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.
Example 1:
Input: [[0, 30],[5, 10],[15, 20]]
Output: 2
Example 2:
Input: [[7,10],[2,4]]
Output: 1
*/

// Comment: This is another optimal solution, which is very neat and clean. Adjusting start before counting rooms.
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
        int len =intervals.Length;
        var s = new int[len];
        var e = new int[len];
        for(int i=0; i<len; i++) {
            s[i] = intervals[i].start;
            e[i] = intervals[i].end;
        }
        Array.Sort(s);
        Array.Sort(e);
        int max = 0, j = 0;
        for(int i=0; i<len; i++) {
            if (s[i]<e[j])
                max++;
            else
                j++;
        }
        return max;
    }
}
