/*
Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

Example:

matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
],
k = 8,

return 13.
Note: 
You may assume k is always valid, 1 <= k <= n^2

*/
// Comment: Similar to N way merge sort. O(k log k)
class Solution {
public:
    int kthSmallest(vector<vector<int>>& matrix, int k) {
        int len = matrix.size();
        auto cmp = [&matrix](int a, int b) {
            return matrix[a].back() < matrix[b].back();
        };
        priority_queue<int, vector<int>,decltype(cmp)> q(cmp);
        for(int i=0; i<len ; i++)
            q.push(i);
        
        int cnt = len * len - k;
        while(q.size()>0) {
            cnt--;
            int i = q.top(); q.pop();
            auto& n = matrix[i];
            if (cnt<0)
                return n.back();

            n.pop_back();
            
            if (n.size()!=0)
                q.push(i);
        }
        return -1;
    }
};
