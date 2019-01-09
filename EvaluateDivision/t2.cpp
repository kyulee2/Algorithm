/*
Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.

Example:
Given a / b = 2.0, b / c = 3.0. 
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? . 
return [6.0, 0.5, -1.0, 1.0, -1.0 ].

The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries , where equations.size() == values.size(), and the values are positive. This represents the equations. Return vector<double>.

According to the example above:

equations = [ ["a", "b"], ["b", "c"] ],
values = [2.0, 3.0],
queries = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ]. 
The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.
*/
// Comment: The key is to pick representative symbol/string to evaluate all connected symbols.
// Say, a-b-c-d, we'd like to get info like a-d, a-c, a-b where is a is a group symbol
class Solution {
public:
    map<string, map<string, double>> m; // string to string with value
    set<string> visited;
    map<string, string> g; // string to group rep
    
    void Rec(string r, string n, double v) {
        visited.insert(n);
        m[r][n] = v;
        g[n] = r; // correlate current t
        for(auto tup : m[n]) {
            if (visited.find(tup.first) != visited.end())
                continue;
            Rec(r, tup.first, v * tup.second);
        }
    }
    
    vector<double> calcEquation(vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries) {
        int len = equations.size();
        for(int i=0; i<len; i++) {
            auto &p = equations[i];
            auto v =values[i];
            m[p.first][p.second] = v;
            if (v!=0.0)
            m[p.second][p.first] = 1/v;
        }
        
        // build correlation rep string to other values
        for(auto tup : m) {
            if (visited.find(tup.first)!=visited.end())
                continue;
            Rec(tup.first, tup.first, 1.0);
        }
        
        // handle queries
        vector<double> ans;
        for(auto &q : queries) {
            auto r = g[q.first];
            auto r2 = g[q.second];
            if (r.empty() || r!=r2) {
                ans.push_back(-1);
                continue;
            }
            
            auto v1 = m[r][q.first];
            auto v2 = m[r][q.second];
            ans.push_back(v2/v1);
        }
        
        return ans;
    }
};