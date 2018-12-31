/*
Given a collection of intervals, find the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping. 
Note:
You may assume the interval's end point is always bigger than its start point.
Intervals like [1,2] and [2,3] have borders "touching" but they don't overlap each other.

Example 1:
Input: [ [1,2], [2,3], [3,4], [1,3] ]

Output: 1

Explanation: [1,3] can be removed and the rest of intervals are non-overlapping.

Example 2:
Input: [ [1,2], [1,2], [1,2] ]

Output: 2

Explanation: You need to remove two [1,2] to make the rest of intervals non-overlapping.

Example 3:
Input: [ [1,2], [2,3] ]

Output: 0

Explanation: You don't need to remove any of the intervals since they're already non-overlapping.
*/
// comment: simple but interesting. learn sort with lamda
// Greedy. Sort by start. Key is how to update end.
// On conflict, pick the ealier end to give the less change of conflict for the next intervals.
// Or, simply update end with the new interval.
/**
 * Definition for an interval.
 * struct Interval {
 *     int start;
 *     int end;
 *     Interval() : start(0), end(0) {}
 *     Interval(int s, int e) : start(s), end(e) {}
 * };
 */
class Solution {
public:
    int eraseOverlapIntervals(vector<Interval>& intervals) {
        int len = intervals.size();
        if (len==0) return 0;        
        sort(intervals.begin(), intervals.end(), [](const Interval &a, const Interval &b) {
            return a.start < b.start;
        });
        int end = intervals[0].end;
        int ans = 0;
        for(int i=1; i<len; i++) {
            auto v = intervals[i];
            if (v.start< end) { // overlap
                ans++;
                // shorter end survives
                end = min(end, v.end);
            } else {
                // update new end
                end = v.end;
            }
        }
            
        
        return ans;
    }
};