/*
Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:

Input: nums = 
[
  [9,9,4],
  [6,6,8],
  [2,1,1]
] 
Output: 4 
Explanation: The longest increasing path is [1, 2, 6, 9].
Example 2:

Input: nums = 
[
  [3,4,5],
  [3,2,6],
  [2,2,1]
] 
Output: 4 
Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
*/

// Comment: This is DFS not BFS. So, visited status is required which should be flipped on and off. Without cacheing, it's time-out. A bit non-intuive to use map with node, but it's guaranteed since the oder(increasing) is forced.

class Solution {
public:
    vector<vector<int>> m;
    set<pair<int, int>> visited;
    map<pair<int, int>, int> cache; // node : max dist
    int Row;
    int Col;
    vector<pair<int,int>> getNext(int i, int j) {
        int val = m[i][j];
        vector<pair<int, int>> v;
        if (i-1>=0 && m[i-1][j]>val) v.push_back(make_pair(i-1,j));
        if (j-1>=0 && m[i][j-1]>val) v.push_back(make_pair(i,j-1));
        if (i+1<Row && m[i+1][j]>val) v.push_back(make_pair(i+1,j));
        if (j+1<Col && m[i][j+1]>val) v.push_back(make_pair(i,j+1));
        return v;
    }
    
    int ans;
    int Rec(pair<int, int> p) {
        int curr = 1;
        if (cache.find(p)!=cache.end())
            return cache[p];
        
        for(auto c : getNext(p.first, p.second)) {
            if (visited.find(c)!=visited.end()) continue;
            visited.insert(c);
            auto h = Rec(c);
            visited.erase(c);
            curr = max(curr, h+1);
        }
        ans = max(ans, curr);
        
        cache[p] = curr;
        return curr;
    }
    
    int longestIncreasingPath(vector<vector<int>>& matrix) {
        ans = 1;
        m = matrix;    
        Row = m.size();
        if (Row==0) return 0;
        Col = m[0].size();
        for(int i=0; i<Row; i++)
            for(int j=0; j<Col; j++) {
                visited.clear();
                auto p = make_pair(i,j);
                visited.insert(p);
                Rec(p);
            }
        
        return ans;
    }
};

