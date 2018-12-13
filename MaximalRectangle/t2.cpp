/*

Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Example:

Input:
[
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
Output: 6

*/
// Comment: Quite interesting. use historgram apporach.
class Solution {
public:
    int getMax(vector<int>& h) {
        stack<int> q;
        int ans = 0;
        for(int i=0; i<h.size(); i++) {
            auto val = h[i];
            while(q.size()!=0 && h[q.top()]>val) {
                auto l = q.top();
                q.pop();
                // Spoiler: The width starts from the prior value in stakc - 1
                int w = q.size()==0 ? i : i - q.top() - 1;
                int area = h[l] * w;
                ans = max(ans, area) ;
            }
            q.push(i);
        }
        return ans;
    }
    
    int maximalRectangle(vector<vector<char>>& matrix) {
        if (matrix.size()==0) return 0;
        vector<int> h(matrix[0].size()+1, 0);
        int ans = 0;
        for(auto cv : matrix) {            
            for(int j=0; j<cv.size(); j++)
                h[j] =cv[j]=='1' ? h[j]+1 : 0;
            ans = max(ans, getMax(h));
        }
        return ans;
    }
};
