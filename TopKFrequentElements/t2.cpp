/*
Given a non-empty array of integers, return the k most frequent elements.
For example,
Given [1,1,1,2,2,3] and k = 2, return [1,2]. 
Note: 
You may assume k is always valid, 1 <= k <= number of unique elements.
Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/
// Comment: This uses priority queue. See t1.cs for O(n) solution using partion
class Solution {
public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        unordered_map<int, int> map;
        unordered_map<int, vector<int>> vmap;
        for(auto n : nums)
            map[n]++;
        
        priority_queue<int, std::vector<int>, std::greater<int>> pq;
        for(auto t: map) {
            vmap[t.second].push_back(t.first);
            pq.push(t.second);
            if (pq.size()>k)
                pq.pop();
        }
        
        vector<int> ans;
        while(pq.size()>0) {
            int t = pq.top();
            pq.pop();
            ans.push_back(vmap[t].back());
            vmap[t].pop_back();
        }
        return ans;
        
    }
};
