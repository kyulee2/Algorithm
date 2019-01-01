/*
 city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A), write a program to output the skyline formed by these buildings collectively (Figure B).

The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x coordinates of the left and right edge of the ith building, respectively, and Hi is its height. It is guaranteed that 0 < Hi <= INT_MAX, and Ri - Li > 0. You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .

The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height. Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.

For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].

Notes:

The number of buildings in any input list is guaranteed to be in the range [0, 10000].
The input list is already sorted in ascending order by the left x position Li.
The output list must be sorted by the x position.
There must be no consecutive horizontal lines of equal height in the output skyline. For instance, [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...[2 3], [4 5], [12 7], ...]
*/

// Comment
// Key idea is when building appears (Start), add its height to Priority queue. When building disappears (End), remove its height from the queue. At each Start/End time point, make sure the current Max height of the queue is changed. If so, output such (time, max) pair to the list.
// Since PQ doesn't provide remove for c++ (n^2 anyhow), the below uses just list and manual insert/remove.
class Solution {
public:
    list<int> q; // height queue (decending order)
    map<int, vector<int>> m; // x to list of up/down height (+,-)
    vector<int> x; // list of x position sorted order
    
    vector<pair<int, int>> getSkyline(vector<vector<int>>& buildings) {
        for(auto &b : buildings) {
            int i = b[0], j=b[1], h=b[2];
            m[i].push_back(h);
            m[j].push_back(-h);
        }
        
        for(auto tup: m) x.push_back(tup.first);
        sort(x.begin(), x.end());
        vector<pair<int, int>> ans;
        int curr = 0;
        
        for(auto i : x) {
            for(auto h : m[i]) {
                if (h>0) {// up
                  auto pos = find_if(q.begin(), q.end(), [h](int a){ return a<=h;});
                  q.insert(pos, h);
                } else {// down
                  auto pos = find(q.begin(), q.end(), -h);
                  q.erase(pos);
                }
            }
            
            int newCurr = q.size()==0 ? 0 :q.front();
            if (curr != newCurr) {
                curr = newCurr;
                ans.push_back(make_pair(i, curr));
            }
        }
        
        return ans;
    }
};
