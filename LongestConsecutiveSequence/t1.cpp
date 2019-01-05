/*
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
Your algorithm should run in O(n) complexity.
Example:
Input: [100, 4, 200, 1, 3, 2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
*/
// Comment: We can store len instead of next idx like t1.cs
class Solution {
public:
    int longestConsecutive(vector<int>& nums) {
        map<long, long> m;        // idx : next idx
        long ans = 0;
        for(auto nt : nums) {
            long n = nt;
            if (m.find(n)!=m.end()) continue;

            // Check neighbor
            bool left = m.find(n-1) != m.end();
            bool right = m.find(n+1) != m.end();
            
            if (left && right) {
                long l = m[n-1], r=  m[n+1];
                ans = max(ans, r-l+1);
                m[l] = r;
                m[r] = l;
                m[n] = n; // empty
            } else if (left) {
                long l = m[n-1];
                ans = max(ans, n - l + 1);
                m[l] = n;
                m[n] = l;
            } else if (right) {
                long r=  m[n+1];
                ans = max(ans, r -n +1);
                m[r] = n;
                m[n] = r;
            } else {
                m[n] = n;
                ans = max(ans, (long) 1);
            }
        }
        
        return (int)ans;
    }
};