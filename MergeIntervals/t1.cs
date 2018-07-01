/*
Given a collection of intervals, merge all overlapping intervals.
Example 1:
Input: [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
Example 2:
Input: [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considerred
*/
// Comment: Tricky to sort IList. I just copied it over to List<T> sort them by start time.
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
    public IList<Interval> Merge(IList<Interval> intervals) {
        int len = intervals.Count;
        if (len==0)
            return intervals;
        
        // Sort intervals by start time
        var list = new List<Interval>(intervals);
        list.Sort((x,y)=>(x.start - y.start));
        
        var ans = new List<Interval>();
        int s = list[0].start;
        int e = list[0].end;
        for(int i=1; i<len; i++) {
            var v = list[i];
            if (v.start <= e) {
                e = Math.Max(e, v.end);
            } else { // publish interval and put new candidate
                ans.Add(new Interval(s, e));
                s = v.start;
                e = v.end;
            }
        }
        
        // Final interval        
        ans.Add(new Interval(s,e));
        
        return ans;
    }
}
