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
// Comment: This method split open/close in separate. Try to sort by start time.
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
    vector<Interval> merge(vector<Interval>& intervals) {
        vector<pair<int, int>> s;
        for(auto i : intervals) {
            s.push_back(pair<int,int>(i.start, 0));
            s.push_back(pair<int,int>(i.end, 1));
        }
        sort(s.begin(), s.end(), [](pair<int,int> a, pair<int,int> b)->bool{
            if (a.first != b.first)
                return a.first < b.first;
            return a.second < b.second;
        }
             );
        
        vector<Interval> ans;
        int status = 0;
        int start = -1;
        for(auto n : s) {
            if (n.second == 0)
                status += 1;
            else status -= 1;
            if (status==1 && start==-1)
                start = n.first;
            if (status == 0) {
                ans.push_back(Interval(start, n.first));
                start = -1;
            }
        }
        return ans;
    }
};
// Another solution using the sorted intervals
class Solution {
public:
    vector<Interval> merge(vector<Interval>& intervals) {
        sort(intervals.begin(), intervals.end(), [](Interval a, Interval b)->bool{
            return a.start < b.start;
        }
             );
        
        vector<Interval> ans;
        if (intervals.size()==0)
            return ans;
        
        int start = intervals[0].start, end = intervals[0].end;
        for(int i=1; i<intervals.size(); i++) {
            auto n = intervals[i];
            if (n.start <= end) {
                end = max(end, n.end);
            } else {
                ans.push_back(Interval(start, end));
                start =n.start;
                end = n.end;
            }
        }
        ans.push_back(Interval(start, end));
        
        return ans;
    }
};
