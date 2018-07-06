/*
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), determine if a person could attend all meetings.
Example 1:
Input: [[0,30],[5,10],[15,20]]
Output: false
Example 2:
Input: [[7,10],[2,4]]
Output: true
*/
// Comment: Similar to find # of rooms as the second solution.
// The first one is straighforward and simpler.
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
    public bool CanAttendMeetings(Interval[] intervals) {
        Array.Sort(intervals, (x,y) => (x.start-y.start));
        for(int i=1; i<intervals.Length; i++)
            if (intervals[i-1].end>intervals[i].start)
                return false;
        return true;
    }
}

public class Solution {
    public bool CanAttendMeetings(Interval[] intervals) {
        int len = intervals.Length;
        var start = new int[len];
        var end = new int[len];
        for(int i=0; i<len; i++) {
            start[i] = intervals[i].start;
            end[i] = intervals[i].end;
        }
        Array.Sort(start);
        Array.Sort(end);
        int rooms = 0;
        int k= 0;
        for(int i=0; i<len ;i++) {
            if (start[i]<end[k])
                rooms++;
            else
                k++;
        }

        return rooms <= 1;
    }
}

